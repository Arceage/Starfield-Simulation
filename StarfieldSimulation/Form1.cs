using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StarfieldSimulation.details;

namespace StarfieldSimulation
{
    public partial class Form1 : Form
    {
        private Star[] stars = new Star[12000];
        private Random random = new Random();
        private Graphics graphics;


        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.Black);

            foreach (var item in stars)
            {
                DrawStar(item);
                moveStar(item);
            }

            pictureBox1.Refresh();
        }

        private void moveStar(Star item)
        {
            item.Z -= 15;
            if (item.Z < 1)
            {
                item.X = random.Next(-pictureBox1.Width, pictureBox1.Width);
                item.Y = random.Next(-pictureBox1.Height, pictureBox1.Height);
                item.Z = random.Next(1, pictureBox1.Width);
            }
        }

        private void DrawStar(Star star)
        {
            float StarSyze = Map(star.Z, 0 , pictureBox1.Width , 10, 0);
            float x = Map(star.X / star.Z, 0 , 1 , 0,  pictureBox1.Width) + pictureBox1.Width / 2;
            float y = Map(star.Y / star.Z, 0, 1, 0 ,  pictureBox1.Height) + pictureBox1.Height / 2;      
            graphics.FillEllipse(Brushes.GreenYellow, x , y, StarSyze, StarSyze);
        }

        private float Map(float num, float start1, float stop1, float start2, float stop2)
        {
            return ((num - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }
      
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            graphics = Graphics.FromImage(pictureBox1.Image);

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star()
                {
                    X = random.Next(-pictureBox1.Width, pictureBox1.Width),
                    Y = random.Next(-pictureBox1.Height, pictureBox1.Height),
                    Z = random.Next(1, pictureBox1.Width),
                };
            }

            timer1.Start();
        }
    }
}
