using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//https://blog.csdn.net/qq_40938169/article/details/83683964

namespace 五子棋_v2
{
	public partial class Form1 : Form
	{

		/// <summary>
		/// 内部计算类
		/// </summary>
		private Chessboard Chessboard = new Chessboard();
		/// <summary>
		/// 是否可落子
		/// </summary>
		private bool ifStart = false;

		/// <summary>
		/// default constructor
		/// </summary>
		public Form1()
		{
			InitializeComponent();
		}

		[System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true)]
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
		static extern bool AllocConsole();

		[System.Runtime.InteropServices.DllImport("Kernel32")]
		public static extern void FreeConsole();//关闭控制台

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			label1.Text = "";
			Chessboard.nowKind.kind = Kinds.Kind.none;
			button1.Enabled = true;
			AllocConsole();
		}

		/// <summary>
		/// 显示坐标
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			label1.Text = "a";
			label1.Text = $"x = {e.X}, y = {e.Y}";
		}

		/// <summary>
		/// 点击"Start"开始
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button1_Click(object sender, EventArgs e)
		{
			label2.Text = "Started";
			ifStart = true;
			Chessboard.nowKind.kind = Kinds.Kind.black;
			button1.Enabled = false;
			// 清空
			pictureBox1.Controls.Clear();
			Chessboard.Clear();
		}

		/// <summary>
		/// 触发落子事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.X < 8 || e.X > 492 || e.Y > 492 || e.Y < 8 || !ifStart)
				return;
			// if (((e.X - 25) % 25 >= 9 && (e.X - 25) % 25 <= 16) || ((e.Y - 25) % 25 >= 9 && (e.Y - 25) % 25 > 16))
			//    return;

			int i = 0, j = 0;

			if ((e.X - 25) % 25 < 9)
				i = (e.X - 25) / 25;
			else if ((e.X - 25) % 25 > 16)
				i = (e.X - 25) / 25 + 1;
			else return;

			if ((e.Y - 25) % 25 < 9)
				j = (e.Y - 25) / 25;
			else if ((e.Y - 25) % 25 > 16)
				j = (e.Y - 25) / 25 + 1;
			else return;


			label2.Text = $"j = {j}, i = {i}";

			makeAChess(i, j);
		}

		/// <summary>
		/// 落子事件
		/// </summary>
		/// <param name="i">位置</param>
		/// <param name="j">位置</param>
		private void makeAChess(int i,int j)
		{
			if (Chessboard.chessBoard[i, j].kind != Kinds.Kind.none)
				return;

			// 添加图片
			PictureBox chess = new PictureBox();
			chess.SizeMode = PictureBoxSizeMode.Zoom;
			chess.BackColor = Color.Transparent;
			chess.Location = new Point((int)(25 + 25 * i - 11), (int)(25 + 25 * j - 11));
			chess.Width = 22;
			chess.Height = 22;
			// chess.

			// 进入Chessboard类
			Chessboard.markAChess(i, j);

			// 添加编号
			Label cNumber = new Label();
			cNumber.Text = $"{Chessboard.chessBoard[i, j].number}";

			// 判断文字及棋子颜色
			if (Chessboard.nowKind.kind == Kinds.Kind.black)
			{
				cNumber.ForeColor = Color.Black;
				chess.Image = Properties.Resources.white;
			}
			else
			{
				cNumber.ForeColor = Color.White;
				chess.Image = Properties.Resources.black;
			}
			pictureBox1.Controls.Add(chess);
			chess.Controls.Add(cNumber);

			// 判断是否结束并显示
			if (Chessboard.ifGameEnd() == Kinds.Kind.black)
			{
				MessageBox.Show("Black Win!");
				ifStart = false;
				label2.Text = "Paused";
				button1.Enabled = true;
			}
			else if (Chessboard.ifGameEnd() == Kinds.Kind.white)
			{
				MessageBox.Show("White Win!");
				ifStart = false;
				label2.Text = "Paused";
				button1.Enabled = true;
			}
			else return;
		}

		/// <summary>
		/// 点击"Exit"退出
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 19; i++)
			{
				for (int j = 0; j < 19; j++)
					Console.Write(Chessboard.boardLine[19 * i + j]);
				Console.WriteLine();
			}

			Point point = Chessboard.MachineLearning();

			label1.Text = $"x = {point.X}, y = {point.Y}";
		}
	}
}
