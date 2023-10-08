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
        float x2, y2;
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
            this.ClientSize = new System.Drawing.Size(600, 600);
            dopaint();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }




        void dopaint()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);

            g.DrawEllipse(new Pen(Color.Black), 390, 50, 140, 140);
            g.FillEllipse(new SolidBrush(Color.Black), 455, 115, 10, 10);
            print_clock_scale(x1, y1, g);
          
            float secRadian = (float)second * pi / 180;
            float minRadian = (float)minute * pi / 180;
            float houRadian = (float)hour * pi / 180;
            draw_clock_line(houRadian, minRadian, secRadian, x1, y1, g, true);


            /*g.DrawString("12", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 70 - 5, 50));
            g.DrawString("6", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 70 - 5, 50 + 140 - 15));
            g.DrawString("3", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 140 - 15, 50 + 140 / 2 - 10));
            g.DrawString("9", new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(390 + 5, 50 + 140 / 2 - 10));
            */
        }

        void print_clock_scale(float centerX, float centerY, Graphics g)
        {
            for (int i = 1; i <= 60; i++)
            {
                float drRadian = (float)i * pi / 180;
                int x = (int)(centerX + 55 * (float)Math.Sin(6 * drRadian));
                int y = (int)(centerY - 55 * (float)(Math.Cos(6 * drRadian)));
                int x_h = (int)(centerX + 70 * (float)Math.Sin(6 * drRadian));
                int y_h = (int)(centerY - 70 * (float)(Math.Cos(6 * drRadian)));
                int x_helf = (int)(centerX + 65 * (float)Math.Sin(6 * drRadian));
                int y_helf = (int)(centerY - 65 * (float)(Math.Cos(6 * drRadian)));
                int x_helf_L = (int)(centerX + 63 * (float)Math.Sin(6 * drRadian));
                int y_helf_L = (int)(centerY - 63 * (float)(Math.Cos(6 * drRadian)));

                if (i % 5 == 0)
                {
                    if (i == 60)
                        g.DrawString((i / 5).ToString(), new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(x - 10, y - 7));
                    else
                        g.DrawString((i / 5).ToString(), new Font("Times New Roman", 10, FontStyle.Bold | FontStyle.Italic), new SolidBrush(Color.Green), new Point(x - 5, y - 7));
                    g.DrawLine(new Pen(Color.Black, 2), x_h, y_h, x_helf_L, y_helf_L);
                }
                else
                {
                    g.DrawLine(new Pen(Color.Black, 1), x_h, y_h, x_helf, y_helf);
                }

            }
        }
        void draw_clock_line(float hurRadian, float midRadian, float secRadian, float centerX, float centerY, Graphics g, bool check_drow_arr)
        {
            float x1Arr, y1Arr, x2Arr, y2Arr;
            float Arr1Radian = (float)(second + 35) * pi / 180, Arr2Radian = (float)(second - 35) * pi / 180;
            x2 = centerX + 60 * (float)Math.Sin(6 * secRadian);
            y2 = centerY - 60 * (float)(Math.Cos(6 * secRadian));
            x1Arr = x2 + 10 * (float)Math.Sin(6 * Arr1Radian);
            y1Arr = y2 - 10 * (float)(Math.Cos(6 * Arr1Radian));
            x2Arr = x2 + 10 * (float)Math.Sin(6 * Arr2Radian);
            y2Arr = y2 - 10 * (float)(Math.Cos(6 * Arr2Radian));
            g.DrawLine(new Pen(Color.Red), centerX, centerY, x2, y2);
            if (check_drow_arr)
            {
                g.DrawLine(new Pen(Color.Red), x2, y2, x1Arr, y1Arr);
                g.DrawLine(new Pen(Color.Red), x2, y2, x2Arr, y2Arr);
            }


            Arr1Radian = (float)(minute + 35) * pi / 180;
            Arr2Radian = (float)(minute - 35) * pi / 180;
            x2 = centerX + 45 * (float)Math.Sin(6 * midRadian);
            y2 = centerY - 45 * (float)(Math.Cos(6 * midRadian));
            x1Arr = x2 + 10 * (float)Math.Sin(6 * Arr1Radian);
            y1Arr = y2 - 10 * (float)(Math.Cos(6 * Arr1Radian));
            x2Arr = x2 + 10 * (float)Math.Sin(6 * Arr2Radian);
            y2Arr = y2 - 10 * (float)(Math.Cos(6 * Arr2Radian));
            g.DrawLine(new Pen(Color.Blue, 5), centerX, centerY, x2, y2);
            if (check_drow_arr)
            {
                g.DrawLine(new Pen(Color.Blue, 3), x2, y2, x1Arr, y1Arr);
                g.DrawLine(new Pen(Color.Blue, 3), x2, y2, x2Arr, y2Arr);
            }


            Arr1Radian = (float)(hour + 35) * pi / 180;
            Arr2Radian = (float)(hour - 35) * pi / 180;
            x2 = centerX + 35 * (float)Math.Sin(6 * hurRadian);
            y2 = centerY - 35 * (float)(Math.Cos(6 * hurRadian));
            g.DrawLine(new Pen(Color.Black, 10), centerX, centerY, x2, y2);
            x2 = centerX + 40 * (float)Math.Sin(6 * hurRadian);
            y2 = centerY - 40 * (float)(Math.Cos(6 * hurRadian));
            x1Arr = x2 + 15 * (float)Math.Sin(6 * Arr1Radian);
            y1Arr = y2 - 15 * (float)(Math.Cos(6 * Arr1Radian));
            x2Arr = x2 + 15 * (float)Math.Sin(6 * Arr2Radian);
            y2Arr = y2 - 15 * (float)(Math.Cos(6 * Arr2Radian));
            if (check_drow_arr)
            {
                g.DrawLine(new Pen(Color.Black, 3), x2, y2, x1Arr, y1Arr);
                g.DrawLine(new Pen(Color.Black, 3), x2, y2, x2Arr, y2Arr);
            }
        }

    }
}


