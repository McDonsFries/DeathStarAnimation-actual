using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace DeathStarAnimation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pixels = 1;
            int bomby = 25;
            int bombx = 250;
            int fPixels = 1;
            int x = 250;
            int y = 310;
            int x2 = 90;
            int y2 = 210;
            int x3 = 340;
            int y3 = 350;

            button1.Hide();
            //create some for loop animations yo
            Graphics g = this.CreateGraphics();
            SolidBrush drawBrush = new SolidBrush(Color.White);
            SolidBrush boomBrush1 = new SolidBrush(Color.Yellow);
            SolidBrush boomBrush2 = new SolidBrush(Color.Orange);
            SolidBrush boomBrush3 = new SolidBrush(Color.Red);
            Pen drawpen = new Pen(Color.Blue, 5);

            for (int i = 0; i < 616; i = i + 8) //First flyby when the plane drops the bomb
            {
                g.Clear(Color.Black);
                g.DrawLine(drawpen, 600 - i, 28, 600 - i, 43);
                g.DrawLine(drawpen, 600 - i, 40, 580 - i, 40);
                g.DrawLine(drawpen, 580 - i, 40, 600 - i, 30);


                if (i >= 300)
                {
                    g.FillRectangle(drawBrush, bombx, bomby, 15, 15);
                    bomby += 7;
                }
                else
                {

                }

                Thread.Sleep(15);
            }
            
            SoundPlayer player = new SoundPlayer(Properties.Resources.bomb);
            player.Play();
            while (pixels <= 300) //Draws the explosion
            {
                 
                g.FillEllipse(boomBrush1, 113 - pixels / 2, 250 - pixels / 2, 400 + pixels, 400 + pixels);
                g.FillEllipse(boomBrush2, 135 - pixels / 2, 280 - pixels / 2, 360 + pixels, 360 + pixels);
                g.FillEllipse(boomBrush3, 157 - pixels / 2, 310 - pixels / 2, 310 + pixels, 310 + pixels);

                Thread.Sleep(10);

                //change
                pixels += 5;
            }
            for (int i = 0; i < 616; i = i + 6) //Another Flyby
            {
                g.Clear(Color.Black);
                g.DrawLine(drawpen, 600 - i, 28, 600 - i, 43);
                g.DrawLine(drawpen, 600 - i, 40, 580 - i, 40);
                g.DrawLine(drawpen, 580 - i, 40, 600 - i, 30);
            }

            while (y > 100) //Firework being fired up into the air
            {
                //act
                g.Clear(Color.Black);
                g.FillEllipse(drawBrush, x, y, 10, 10);
                g.FillEllipse(drawBrush, x2, y2, 10, 10);
                g.FillEllipse(drawBrush, x3, y3, 10, 10);

                Thread.Sleep(5);

                //change
                //x++;
                y--;
                y2--;
                y3--;
            }

            SoundPlayer play = new SoundPlayer(Properties.Resources.firework);
            play.Play();
            while (fPixels < 100) //Firework actaully exploding
            {
                //act
                SolidBrush fireworkBrush = new SolidBrush(Color.Lime);
                SolidBrush fireworkBrush2 = new SolidBrush(Color.LightBlue);
                SolidBrush fireworkBrush3 = new SolidBrush(Color.OrangeRed);
                g.Clear(Color.Black);
                g.FillEllipse(fireworkBrush, 250 - fPixels / 2, 100 - fPixels / 2, 15 + fPixels, 15 + fPixels);
                g.FillEllipse(fireworkBrush2, 90 - fPixels / 2, 30 - fPixels / 2, 15 + fPixels, 15 + fPixels);
                g.FillEllipse(fireworkBrush3, 330 - fPixels / 2, 70 - fPixels / 2, 15 + fPixels, 15 + fPixels);

                Thread.Sleep(10);

                //change
                fPixels++;
            }
            Thread.Sleep(1000);
            g.Clear(Color.Black);
            Font drawFont = new Font("Times New Roman", 14, FontStyle.Bold);
            SolidBrush wordBrush = new SolidBrush(Color.Blue);
            g.DrawString ("Thank you for coming to the 2016 bad animation show!!", drawFont, wordBrush, 20, 100);
        }

    }
}
