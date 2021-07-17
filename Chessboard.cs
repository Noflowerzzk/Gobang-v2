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

		/// <summary>
		/// 棋盘线性表
		/// </summary>
		public double[] boardLine = new double[361];

		//https://www.cnblogs.com/songdechiu/p/5768999.html#:~:text=%E4%B8%80%E3%80%81%E4%BA%94%E5%AD%90%E6%A3%8B%E5%9F%BA%E6%9C%AC%E6%A3%8B%E5%9E%8B.%20%E6%9C%80%E5%B8%B8%E8%A7%81%E7%9A%84%E5%9F%BA%E6%9C%AC%E6%A3%8B%E5%9E%8B%E5%A4%A7%E4%BD%93%E6%9C%89%E4%BB%A5%E4%B8%8B%E5%87%A0%E7%A7%8D%EF%BC%9A%20%E8%BF%9E%E4%BA%94%EF%BC%8C%E6%B4%BB%E5%9B%9B%EF%BC%8C%E5%86%B2%E5%9B%9B%EF%BC%8C%E6%B4%BB%E4%B8%89%EF%BC%8C%E7%9C%A0%E4%B8%89%EF%BC%8C%E6%B4%BB%E4%BA%8C%EF%BC%8C%E7%9C%A0%E4%BA%8C%20%E3%80%82.%20%E2%91%A0%E8%BF%9E%E4%BA%94%20%EF%BC%9A%E9%A1%BE%E5%90%8D%E6%80%9D%E4%B9%89%EF%BC%8C%E4%BA%94%E9%A2%97%E5%90%8C%E8%89%B2%E6%A3%8B%E5%AD%90%E8%BF%9E%E5%9C%A8%E4%B8%80%E8%B5%B7%EF%BC%8C%E4%B8%8D%E9%9C%80%E8%A6%81%E5%A4%9A%E8%AE%B2%E3%80%82.%20%E2%91%A1%E6%B4%BB%E5%9B%9B,%EF%BC%9A%E6%9C%89%E4%B8%A4%E4%B8%AA%E8%BF%9E%E4%BA%94%E7%82%B9%EF%BC%88%E5%8D%B3%E6%9C%89%E4%B8%A4%E4%B8%AA%E7%82%B9%E5%8F%AF%E4%BB%A5%E5%BD%A2%E6%88%90%E4%BA%94%EF%BC%89%EF%BC%8C%E5%9B%BE%E4%B8%AD%E7%99%BD%E7%82%B9%E5%8D%B3%E4%B8%BA%E8%BF%9E%E4%BA%94%E7%82%B9%E3%80%82.%20%E7%A8%8D%E5%BE%AE%E6%80%9D%E8%80%83%E4%B8%80%E4%B8%8B%E5%B0%B1%E8%83%BD%E5%8F%91%E7%8E%B0%E6%B4%BB%E5%9B%9B%E5%87%BA%E7%8E%B0%E7%9A%84%E6%97%B6%E5%80%99%EF%BC%8C%E5%A6%82%E6%9E%9C%E5%AF%B9%E6%96%B9%E5%8D%95%E7%BA%AF%E8%BF%87%E6%9D%A5%E9%98%B2%E5%AE%88%E7%9A%84%E8%AF%9D%EF%BC%8C%E6%98%AF%E5%B7%B2%E7%BB%8F%E6%97%A0%E6%B3%95%E9%98%BB%E6%AD%A2%E8%87%AA%E5%B7%B1%E8%BF%9E%E4%BA%94%E4%BA%86%E3%80%82.%20%E2%91%A2%E5%86%B2%E5%9B%9B%20%EF%BC%9A%E6%9C%89%E4%B8%80%E4%B8%AA%E8%BF%9E%E4%BA%94%E7%82%B9%EF%BC%8C%E5%A6%82%E4%B8%8B%E9%9D%A2%E4%B8%89%E5%9B%BE%EF%BC%8C%E5%9D%87%E4%B8%BA%E5%86%B2%E5%9B%9B%E6%A3%8B%E5%9E%8B%E3%80%82.%20%E5%9B%BE%E4%B8%AD%E7%99%BD%E7%82%B9%E4%B8%BA%E8%BF%9E%E4%BA%94%E7%82%B9%E3%80%82.%20%E7%9B%B8%E5%AF%B9%E6%AF%94%E6%B4%BB%E5%9B%9B%E6%9D%A5%E8%AF%B4%EF%BC%8C%E5%86%B2%E5%9B%9B%E7%9A%84%E5%A8%81%E8%83%81%E6%80%A7%E5%B0%B1%E5%B0%8F%E4%BA%86%E5%BE%88%E5%A4%9A%EF%BC%8C%E5%9B%A0%E4%B8%BA%E8%BF%99%E4%B8%AA%E6%97%B6%E5%80%99%EF%BC%8C%E5%AF%B9%E6%96%B9%E5%8F%AA%E8%A6%81%E8%B7%9F%E7%9D%80%E9%98%B2%E5%AE%88%E5%9C%A8%E9%82%A3%E4%B8%AA%E5%94%AF%E4%B8%80%E7%9A%84%E8%BF%9E%E4%BA%94%E7%82%B9%E4%B8%8A%EF%BC%8C%E5%86%B2%E5%9B%9B%E5%B0%B1%E6%B2%A1%E6%B3%95%E5%BD%A2%E6%88%90%E8%BF%9E%E4%BA%94%E3%80%82.%20%E2%91%A3%E6%B4%BB%E4%B8%89%20%EF%BC%9A%E5%8F%AF%E4%BB%A5%E5%BD%A2%E6%88%90%E6%B4%BB%E5%9B%9B%E7%9A%84%E4%B8%89%EF%BC%8C%E5%A6%82%E4%B8%8B%E5%9B%BE%EF%BC%8C%E4%BB%A3%E8%A1%A8%E4%B8%A4%E7%A7%8D%E6%9C%80%E5%9F%BA%E6%9C%AC%E7%9A%84%E6%B4%BB%E4%B8%89%E6%A3%8B%E5%9E%8B%E3%80%82.
		/// <summary>
		/// 棋形,1为同色,0为无,-1为异色或墙
		/// </summary>
		public int[] Condition1 = { 1, 1, 1, 1, 1 };        // 连五   100000
		public int[] Condition2 = { 0, 1, 1, 1, 1, 0 };     // 活四   1000
		public int[] Condition3 = { 0, 1, 1, 1, 1, -1 };    // 冲四1  500
		public int[] Condition4 = { -1, 1, 1, 1, 1, 0 };    // 冲四2
		public int[] Condition5 = { 1, 0, 1, 1, 1 };        // 冲四3
		public int[] Condition6 = { 1, 1, 1, 0, 1 };        // 冲四4
		public int[] Condition7 = { 1, 1, 0, 1, 1 };        // 冲四5
		public int[] Condition8 = { 0, 1, 1, 1, 0 };        // 活三1
		public int[] Condition9 = { 0, 1, 0, 1, 1, 0 };
		public int[] Condition10 = { 0, 1, 1, 0, 1, 0 };    // pause*
		public int[] Condition11 = { 0, 1, 0, 1, 1 };
		public int[] Condition12 = { 1, 0, 1, 1, 0 };

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
				{
					chessBoard[i, j] = new Kinds(Kinds.Kind.none);
					boardLine[19 * j + i] = 0;
				}
			
			
			Console.WriteLine("aa");

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

			if (nowKind.kind == Kinds.Kind.black)
				boardLine[19 * j + i] = 1;
			else if (nowKind.kind == Kinds.Kind.white)
				boardLine[19 * j + i] = 2;

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

		public void MachineLearning()
		{
			// 创建群落

		}
	}
}
