using System;
using System.Drawing;
using System.Windows.Forms;

namespace ColorLines
{
    
    public enum Item
    {
        none,
        ball,
        jump,
        next,
        path
    }

    public struct Ball
    {
        public int x;
        public int y;
        public int color;
    }

    public delegate void ShowItem(Ball ball, Item item);
    public delegate void ShowPrice(int x);
    public partial class Form1 : Form
    {
        int max = 9;
        int size = 60;
        PictureBox[,] box;
        Game game;
        int score = 0;


        public Form1()
        {
            InitializeComponent();
            CreateBoxes();
            game = new Game(max, ShowItem, ShowPrice);
            timer1.Enabled = true;
        }

        public void CreateBoxes()
        {
            panel.Size = new Size(size * max, size * max);
            box = new PictureBox[max, max];

            for (int x = 0; x < max; x++)
                for (int y = 0; y < max; y++)
                {
                    box[x, y] = new PictureBox();
                    box[x, y].BorderStyle = BorderStyle.FixedSingle;
                    box[x, y].Location = new Point(x * size, y * size);
                    box[x, y].Size = new Size(size, size);
                    box[x, y].Image = Properties.Resources.empty;
                    panel.Controls.Add(box[x, y]);
                    box[x, y].SizeMode = PictureBoxSizeMode.Zoom;
                    box[x, y].Click += new System.EventHandler(this.ClickBox);
                    box[x, y].Tag = new Point(x, y);
                }
        }

        private void ClickBox(object sender, EventArgs e)
        {
            Point xy = (Point)((PictureBox)sender).Tag;
            game.ClickBox(xy.X, xy.Y);
        }


        private Image imgBall(int nr)
        {
            switch (nr)
            {
                case 1: return Properties.Resources._1b;
                case 2: return Properties.Resources._2b;
                case 3: return Properties.Resources._3b;
                case 4: return Properties.Resources._4b;
                case 5: return Properties.Resources._5b;
                case 6: return Properties.Resources._6b;
            }
            return null;
        }

        private Image imgJump(int nr)
        {
            switch (nr)
            {
                case 1: return Properties.Resources._1n;
                case 2: return Properties.Resources._2n;
                case 3: return Properties.Resources._3n;
                case 4: return Properties.Resources._4n;
                case 5: return Properties.Resources._5n;
                case 6: return Properties.Resources._6n;
            }
            return null;
        }

        private Image imgNext(int nr)
        {
            switch (nr)
            {
                case 1: return Properties.Resources._1s;
                case 2: return Properties.Resources._2s;
                case 3: return Properties.Resources._3s;
                case 4: return Properties.Resources._4s;
                case 5: return Properties.Resources._5s;
                case 6: return Properties.Resources._6s;
            }
            return null;
        }

        private void ShowItem(Ball ball, Item item)
        {
            Image image;

            switch (item)
            {
                case Item.none: image = Properties.Resources.empty; break;
                case Item.ball: image = imgBall(ball.color); break;
                case Item.jump: image = imgJump(ball.color); break;
                case Item.next: image = imgNext(ball.color); break;
                case Item.path: image = Properties.Resources.path; break;
                default: image = Properties.Resources.empty; break;
            }


            box[ball.x, ball.y].Image = image;
        }

        private void ShowPrice(int x)
        {
            score += x * 10;
            label1.Text = score.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.Step();           
        }
    }
}
