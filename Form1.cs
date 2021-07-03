using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//https://blog.csdn.net/qq_40938169/article/details/83683964

namespace 五子棋_v2
{
    public partial class Form1 : Form
    {
        const double cell = 25;

        private Kinds.Kind nowKind;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            nowKind = Kinds.Kind.none;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = "a";
            label1.Text = $"x = {e.X}, y = {e.Y}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "a";
            nowKind = Kinds.Kind.black;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X < 8 || e.X > 492 || e.Y > 492 || e.Y < 8)
                return;

            int i = 0, j = 0;

            if ((e.X - 25) % 25 < 9)
                j = (e.X - 25) / 25;
            if ((e.X - 25) % 25 > 16)
                j = (e.X - 25) / 25 + 1;

            if ((e.Y - 25) % 25 < 9)
                i = (e.Y - 25) / 25;
            if ((e.Y - 25) % 25 > 16)
                i = (e.Y - 25) / 25 + 1;


            label2.Text = $"j = {j}, i = {i}";

            PictureBox chess = new PictureBox();

            chess.SizeMode = PictureBoxSizeMode.Zoom;
            chess.BackColor = Color.Transparent;
            chess.Location = new Point((int)(25 + 25 * j - 9), (int)(25 + 25 * i - 9));
            chess.Width = 18;
            chess.Height = 18;
            // chess.

            if (nowKind == Kinds.Kind.black)
            {
                chess.Image = Properties.Resources.black;
            }
            else
            {
                chess.Image = Properties.Resources.white;
            }
            pictureBox1.Controls.Add(chess);
            // if()
        }
    }
}
