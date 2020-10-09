using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋
{
    public partial class Form1 : Form
    {
        const int sizex = 400 + 20;
        const int sizey = 400 + 50;
        Image black = Properties.Resources.Black;
        Image white = Properties.Resources.White;
        Image back = Properties.Resources.background;
        int[,] keyboard = new int[19, 19];//null=0，black=1；white=-1
        bool blacknow = true;
        bool start = false;
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(sizex, sizey);
        }
        private void initkeyboard()
        {
            start = true;//开始
            blacknow = true;
            for (int i = 0; i < 19; i++)//初始化数字棋盘
                for (int j = 0; j < 19; j++)
                    keyboard[i, j] = 0;
            for (int i = 0; i < 19; i++)//初始化图形化棋盘
                for (int j = 0; j < 19; j++)
                    drawbackground(i, j);
            Graphics g = this.CreateGraphics();
            g.DrawString("0", this.Font, Brushes.Black, 0, 0);
            for (int i = 0; i < 19; i++)
                g.DrawString((i + 1).ToString(), this.Font, Brushes.Black, (i + 1) * 20, 0);
            for (int j = 0; j < 19; j++)
                g.DrawString((j + 1).ToString(), this.Font, Brushes.Black, 0, (j + 1) * 20);
        }

        private void drawbackground(int i, int j)
        {
            Graphics g = this.CreateGraphics();
            Point[] points = new Point[] { new Point(i * 20 + 20, j * 20 + 20), new Point(i * 20 + 40, j * 20 + 20), new Point(i * 20 + 20, j * 20 + 40) };
            g.DrawImage(back, points);
        }

        private void 初始化棋盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            initkeyboard();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (start)
            {
                int i = e.X / 20;
                int j = e.Y / 20;
                Graphics g = this.CreateGraphics();
                //MessageBox.Show(i + " " + j);
                if (blacknow)//黑[1,1]...[19,19]
                {
                    if (keyboard[i - 1, j - 1] == 0)
                    {
                        keyboard[i - 1, j - 1] = 1;
                        blacknow = false;
                        Point[] points = new Point[] { new Point(i * 20, j * 20), new Point(i * 20 + 20, j * 20), new Point(i * 20, j * 20 + 20) };
                        g.DrawImage(black, points);
                    }
                }
                else//百
                {
                    if (keyboard[i - 1, j - 1] == 0)
                    {
                        keyboard[i - 1, j - 1] = -1;
                        blacknow = true;
                        Point[] points = new Point[] { new Point(i * 20, j * 20), new Point(i * 20 + 20, j * 20), new Point(i * 20, j * 20 + 20) };
                        g.DrawImage(white, points);
                    }
                }
                judge();//判断胜负
            }
            else
            {
                MessageBox.Show("请右键初始化棋盘开始游戏！");
            }
        }

        private void judge()
        {
            int[,] a = keyboard;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    //左上
                    if (start)
                    {
                        try
                        {
                            int x = a[i, j] + a[i - 1, j - 1] + a[i - 2, j - 2] + a[i - 3, j - 3] + a[i - 4, j - 4];
                            if (x == 5) { MessageBox.Show("黑子赢"); start = false; }
                            else if (x == -5) { MessageBox.Show("白子赢"); start = false; }
                        }
                        catch { }
                        //右下
                        try
                        {
                            int x = a[i, j] + a[i + 1, j + 1] + a[i + 2, j + 2] + a[i + 3, j + 3] + a[i + 4, j + 4];
                            if (x == 5) { MessageBox.Show("黑子赢"); start = false; }
                            else if (x == -5) { MessageBox.Show("白子赢"); start = false; }
                        }
                        catch { }
                        //右上
                        try
                        {
                            int x = a[i, j] + a[i + 1, j - 1] + a[i + 2, j - 2] + a[i + 3, j - 3] + a[i + 4, j - 4];
                            if (x == 5) { MessageBox.Show("黑子赢"); start = false; }
                            else if (x == -5) { MessageBox.Show("白子赢"); start = false; }
                        }
                        catch { }
                        //左下
                        try
                        {
                            int x = a[i, j] + a[i - 1, j + 1] + a[i - 2, j + 2] + a[i - 3, j + 3] + a[i - 4, j + 4];
                            if (x == 5) { MessageBox.Show("黑子赢"); start = false; }
                            else if (x == -5) { MessageBox.Show("白子赢"); start = false; }
                        }
                        catch { }
                        //左
                        try
                        {
                            int x = a[i, j] + a[i - 1, j] + a[i - 2, j] + a[i - 3, j] + a[i - 4, j];
                            if (x == 5) { MessageBox.Show("黑子赢"); start = false; }
                            else if (x == -5) { MessageBox.Show("白子赢"); start = false; }
                        }
                        catch { }
                        //右
                        try
                        {
                            int x = a[i, j] + a[i + 1, j] + a[i + 2, j] + a[i + 3, j] + a[i + 4, j];
                            if (x == 5) { MessageBox.Show("黑子赢"); start = false; }
                            else if (x == -5) { MessageBox.Show("白子赢"); start = false; }
                        }
                        catch { }
                        //上
                        try
                        {
                            int x = a[i, j] + a[i, j - 1] + a[i, j - 2] + a[i, j - 3] + a[i, j - 4];
                            if (x == 5) { MessageBox.Show("黑子赢"); start = false; }
                            else if (x == -5) { MessageBox.Show("白子赢"); start = false; }
                        }
                        catch { }
                        //下
                        try
                        {
                            int x = a[i, j] + a[i, j + 1] + a[i, j + 2] + a[i, j + 3] + a[i, j - +4];
                            if (x == 5) { MessageBox.Show("黑子赢"); start = false; }
                            else if (x == -5) { MessageBox.Show("白子赢"); start = false; }
                        }
                        catch { }
                    }
                }
            }
        }
    }
}
