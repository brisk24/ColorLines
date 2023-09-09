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
        public Form1()
        {
            InitializeComponent();
            CreateBoxes();
        }

        public void CreateBoxes()
        {
            panel.Size = new Size(size * max, size * max); 
            box = new PictureBox[max, max];
            for(int x = 0; x < max; x++)
                for(int y = 0; y < max; y++)
                {
                    box[x, y] = new PictureBox();                  
                    box[x, y].BorderStyle = BorderStyle.FixedSingle;                   
                    box[x, y].Location = new Point(x * size, y * size);               
                    box[x, y].Size = new Size(size, size);
                    box[x, y].Image = Properties.Resources._6b;
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
    }
}
