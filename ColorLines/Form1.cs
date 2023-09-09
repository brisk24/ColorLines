using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorLines
{
    public partial class Form1 : Form
    {
        int max = 9;
        int size = 60;
        PictureBox[,] box;
        int[,] map;// 0-пусто, 1-6 шарик цвета N

        enum Item
        {
            none,
            ball,
            jump,
            next,
            path
        }
        public Form1()
        {
            InitializeComponent();
            CreateBoxes();
            ShowItem(2, 3, Item.ball, 5);
            ShowItem(4, 2, Item.jump, 3);
            ShowItem(1, 6, Item.next, 2);
        }

        public void CreateBoxes()
        {
            panel.Size = new Size(size * max, size * max);
            box = new PictureBox[max, max];
            map = new int[max, max];
            for (int x = 0; x < max; x++)
                for (int y = 0; y < max; y++)
                {
                    map[x, y] = 0;
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
            MessageBox.Show($"{xy.X} {xy.Y}");
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
                case 1: return Properties.Resources._1s;
                case 2: return Properties.Resources._2s;
                case 3: return Properties.Resources._3s;
                case 4: return Properties.Resources._4s;
                case 5: return Properties.Resources._5s;
                case 6: return Properties.Resources._6s;
            }
            return null;
        }

        private Image imgNext(int nr)
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

        private void ShowItem(int x, int y, Item item, int color)
        {
            Image image;

            switch (item)
            {
                case Item.none: image = Properties.Resources.empty; break;
                case Item.ball: image = imgBall(color); break;
                case Item.jump: image = imgJump(color); break;
                case Item.next: image = imgNext(color); break;
                case Item.path: image = Properties.Resources.path; break;
                default: image = Properties.Resources.empty; break;
            }


            box[x, y].Image = image;
        }
    }
}
