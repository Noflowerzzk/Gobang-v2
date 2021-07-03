using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋_v2
{
    class Chessboard
    {
        // 棋盘
        public Kinds[,] chessBoard = new Kinds[19, 19];

        public Kinds nowKind = new Kinds(Kinds.Kind.none);

        private int number = 0; // 编号

        // 方向向量
        private Point[] v = new Point[8];

        /// <summary>
        /// constructor
        /// </summary>
        public Chessboard()
        {
            for (int i = 0; i < 19; i++)
                for (int j = 0; j < 19; j++)
                    chessBoard[i, j] = new Kinds(Kinds.Kind.none);

            v[0] = new Point(0, 1);     // up
            v[1] = new Point(1, 1);     // up right
            v[2] = new Point(1, 0);     // right
            v[3] = new Point(1, -1);    // down right
            v[4] = new Point(0, -1);    // down
            v[5] = new Point(-1, -1);   // down left
            v[6] = new Point(-1, 0);    // left
            v[7] = new Point(-1, 1);    // up left
        }

        /// <summary>
        /// 落子标记
        /// </summary>
        /// <param name="i">位置</param>
        /// <param name="j">位置</param>
        public void markAChess( int i, int j)
        {
            number++;
            chessBoard[i, j].kind = nowKind.kind;
            chessBoard[i, j].number = number;

            nowKind.setOppositeKind();
        }

        /// <summary>
        /// 判断是否连子
        /// </summary>
        /// <param name="N">判断的连子数目</param>
        /// <param name="chess">传入颜色等信息</param>
        /// <param name="x">位置(用于外部循环)</param>
        /// <param name="y">位置(用于外部循环)</param>
        /// <returns>bool:是否</returns>
        public bool ifLucky(int N, Kinds chess, int x, int y)
        {
            int n_ = 0; // 连子数目

            for(int i_ = 0; i_ < 4; i_++)
            {
                n_ = 0;
                for (int i = x - (N - 1) * v[i_].X, j = y - (N - 1) * v[i_].Y;
                    i <= x + (N - 1) * v[i_].X&& j <= y + (N - 1) * v[i_].Y;
                    i = i + v[i_].X, j = j + v[i_].Y)
                {
                    // 越界检查
                    if (i < 0 || i >= 19 || j < 0 || j >= 19)
                        continue;

                    if (chessBoard[i, j].kind == chess.kind)
                        n_++;
                    else
                        n_ = 0;

                    if (n_ == N)
                        return true;
                }
                // 该点处无
            }

            return false;
        }

        /// <summary>
        /// 判断有无胜利
        /// </summary>
        /// <returns>返回胜利者颜色,若无,则返回none</returns>
        public Kinds.Kind ifGameEnd()
        {
            for (int i = 0; i < 19; i++)
                for (int j = 0; j < 19; j++)
                {
                    if (ifLucky(5, new Kinds(Kinds.Kind.black), i, j))
                        return Kinds.Kind.black;
                    else if (ifLucky(5, new Kinds(Kinds.Kind.white), i, j))
                        return Kinds.Kind.white;
                }

            return Kinds.Kind.none;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < 19; i++)
                for (int j = 0; j < 19; j++)
                    if (chessBoard[i, j].kind != Kinds.Kind.none)
                        chessBoard[i, j].kind = Kinds.Kind.none;

            nowKind.kind = Kinds.Kind.black;

            number = 0;
        }
    }
}
