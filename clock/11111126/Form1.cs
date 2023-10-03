using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11111126
{
    public partial class Form1 : Form
    {
        float x1 = 460.0F, y1 = 115.0F;
        float x2, y2, x3, y3, x4, y4;
        const float pi = 3.141592654F;
        int second = DateTime.Now.Second;
        int minute = DateTime.Now.Minute;
        int hour = DateTime.Now.Hour * 5;



        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second++;
            if (second == 60)
            {
                minute++;
                second = 0;
            }
            if (minute == 60)
            {
                hour += 5;
                minute = 0;
            }
            if (hour == 24)
            {
                hour = 0;
            }
            dopaint();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(600, 600);
            dopaint();
        }




        void dopaint()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);

            g.DrawEllipse(new Pen(Color.Black), 390, 50, 140, 140);
            g.FillEllipse(new SolidBrush(Color.Black), 455, 115, 10, 10);
            //中心點：(460, 120)
            /*g.DrawEllipse(new Pen(Color.Black), 220, 50, 140, 140);
            g.FillEllipse(new SolidBrush(Color.Black), 285, 115, 10, 10);*/
            //碼表

            float secRadian = (float)second * pi / 180;
            float minRadian = (float)minute * pi / 180;
            float houRadian = (float)hour * pi / 180;

            x2 = x1 + 50 * (float)(Math.Sin(6 * secRadian));
            y2 = y1 - 50 * (float)(Math.Cos(6 * secRadian));


            x3 = x1 + 35 * (float)(Math.Sin(6 * minRadian));
            y3 = y1 - 35 * (float)(Math.Cos(6 * minRadian));

            x4 = x1 + 20 * (float)(Math.Sin(6 * houRadian));
            y4 = y1 - 20 * (float)(Math.Cos(6 * houRadian));
            /*
            x2 = x1 + 60 * (float)(Math.Sin(6 * secRadian));
            y2 = y1 - 60 * (float)(Math.Cos(6 * secRadian));
             */

            g.DrawLine(new Pen(Color.Red, 1), x1, y1, x2, y2);
            g.DrawLine(new Pen(Color.Blue, 5), x1, y1, x3, y3);
            g.DrawLine(new Pen(Color.Black, 10), x1, y1, x4, y4);

            g.DrawString("12", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 70 - 5, 50));
            g.DrawString("6", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 70 - 5, 50 + 140 - 15));
            g.DrawString("3", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 140 - 15, 50 + 140 / 2 - 10));
            g.DrawString("9", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 5, 50 + 140 / 2 - 10));





        }
    }
}


