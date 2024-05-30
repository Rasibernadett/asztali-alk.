using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotokMozgasaSzalakkal
{
    public partial class Form1 : Form
    {
        private bool kell_rajzolni = false;
        int elozo_x = 0;
        int elozo_y = 0;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button gomb = (Button)sender;

            //if(((Button)sender).Text=="Szabadkézi: Be")
            if (gomb.Text == "Szabadkézi: Be")
            {

                //((Button)sender).Text = "Szabadkézi: Ki";
                gomb.Text = "Szabadkézi: Ki";
                //kell_rajzolni= true;
                this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            }
            else
            {
                gomb.Text = "Szabadkézi: Be";
                //kell_rajzolni= false;
                this.MouseMove -= Form1_MouseMove;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            /*if (kell_rajzolni)
            {*/
            elozo_x = e.X;
            elozo_y = e.Y;
            kell_rajzolni = true;
            /* }*/
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (kell_rajzolni)
            {
                this.CreateGraphics().DrawLine(
                                            new Pen(Color.Red),
                                            elozo_x, elozo_y,
                                            e.X, e.Y);
                elozo_x = e.X;
                elozo_y = e.Y;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            kell_rajzolni = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            int bal = rnd.Next(0, this.ClientSize.Width);
            int felso = rnd.Next(0, this.ClientSize.Height);
            int szelesseg = rnd.Next(100, 600);
            int magassag = rnd.Next(100, 400);
            this.CreateGraphics().DrawRectangle(
                                            new Pen(Color.FromArgb(r, g, b)),
                                            bal, felso,
                                            szelesseg, magassag);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            int bal = rnd.Next(0, this.ClientSize.Width);
            int felso = rnd.Next(0, this.ClientSize.Height);
            int szelesseg = rnd.Next(100, 400);
            //int magassag = rnd.Next(100, 400);
            /*this.CreateGraphics().DrawEllipse(
                                            new Pen(Color.FromArgb(r, g, b)),
                                            bal, felso,
                                            szelesseg, szelesseg);*/
            //Rajzolás tollal(Pen), Festés ecsettel(Brush)
            this.CreateGraphics().FillEllipse(
                                            new SolidBrush(Color.FromArgb(r, g, b)),
                                            bal, felso,
                                            szelesseg, szelesseg);

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Point[] pontok = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                pontok[i] = new Point(rnd.Next(100, 400), rnd.Next(100, 400));
                this.CreateGraphics().FillRectangle(new SolidBrush(Color.Black),
                    pontok[i].X - 2, pontok[i].Y - 2, 5, 5);
                Thread.Sleep(1000);
            }
            for (int i = 1; i < pontok.Length; i++)
            {
                this.CreateGraphics().DrawLine(new Pen(Color.Black),
                    pontok[i - 1].X, pontok[i - 1].Y);





            }
        }

    }
}
