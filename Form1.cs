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
            PictureBox chess = new PictureBox();

            if (nowKind == Kinds.Kind.black)
                chess.BackgroundImage = Properties.Resources.black;
            else
                chess.BackgroundImage = Properties.Resources.white;

            chess.SizeMode = PictureBoxSizeMode.Zoom;
            chess.Location = new Point(e.X - 13, e.Y - 13);
            chess.Width = 26;
            chess.Height = 26;
        }
    }
}
