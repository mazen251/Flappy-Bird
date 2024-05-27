using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGame_MM
{
    class actor 
    {
        public int X, Y;
        public Bitmap img;
        public int gravity = 15;
    }

    class actor2
    {
        public int X, Y; 
        public Bitmap img;
        public int Speed = 10;
    }

    public partial class Form1 : Form
    {
        Bitmap off;
        
        int Yborder;
        int ctTick = 0;
        Timer t = new Timer(); 
        actor lhero = new actor();
        List<actor2> llowerpipe = new List<actor2>();
        List<actor2> lupperpipe = new List<actor2>();

        public Form1()
        {
            this.Load += new EventHandler(Form1_Load);
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
            this.WindowState = FormWindowState.Maximized;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        void Form1_KeyDown(object sender, KeyEventArgs e) 
        {
            if (e.KeyCode == Keys.Space)
            {
                lhero.gravity = -40;
            }       
        }

        void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                lhero.gravity = 25;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);   

            Yborder = this.ClientSize.Height;

            createbird();

            createlowerpipes();

            createupperpipes();

        }


        void createbird()
        {
            actor pnn = new actor();
            pnn.X = 200;
            pnn.Y = 520;
            pnn.img = new Bitmap("1.bmp");
            pnn.img.MakeTransparent(pnn.img.GetPixel(0, 0));
            lhero = pnn;
        }

        void animatebird()
        {
            lhero.Y += lhero.gravity;

           
        }

        void createupperpipes()
        {
            lupperpipe = new List<actor2>();
            int ax = 10;

            for (int i = 0; i < 90; i++)
            {
                actor2 pnn = new actor2();
                pnn.img = new Bitmap("2.bmp");
                pnn.X = ax;
                pnn.Y = -450;
                lupperpipe.Add(pnn);
                ax += pnn.img.Width;
            }
        }




        //void CreateNewpipe()
        //{
        //    int ax = 10;
        //    Random RR = new Random();
        //    Random RRR = new Random();
        //    actor2 pnn = new actor2(); // lower
        //    actor2 pnn2 = new actor2();// upper

        //    pnn.X = ax;
        //    pnn2.X = ax;

        //    int j = 0;

        //    for (int i = 0; i < 90 ; i++)
        //    {


        //        pnn.Y = RR.Next(llowerpipe[i].Y + llowerpipe[i].img.Width, llowerpipe[i + 1].Y);


        //        pnn2.Y = RRR.Next(lupperpipe[j].Y + lupperpipe[j].img.Width, lupperpipe[j + 1].Y);


        //        j++;

        //    }





        //    pnn.img = new Bitmap("3.bmp");
        //    pnn2.img = new Bitmap("2.bmp");

        //    lupperpipe.Add(pnn);
        //    llowerpipe.Add(pnn2);
        //}

        void animateupperpipes()
        {
            for (int i = 0; i < lupperpipe.Count; i++)
            {
                lupperpipe[i].X -= 8;
            }
        }

        void createlowerpipes()
        {
            llowerpipe = new List<actor2>();
            int ax = 10;

            for (int i = 0; i < 90; i++)
            {
                actor2 pnn = new actor2();
                pnn.img = new Bitmap("3.bmp");
                pnn.X = ax;
                pnn.Y = 450;
                llowerpipe.Add(pnn);
                ax += pnn.img.Width;
            }
        }





        void animatlowerpipes()
        {
            for (int i = 0; i < llowerpipe.Count; i++)
            {
                llowerpipe[i].X -= 8;
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            //if (ctTick % 20 == 0)
            //{
            //    CreateNewBox1();
                
            //}

           

                animatebird();

                animateupperpipes();

                animatlowerpipes();
            

            DrawDubb(this.CreateGraphics());
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        void DrawScene(Graphics g)
        {
            g.Clear(Color.LightBlue);

            g.DrawImage(lhero.img, lhero.X, lhero.Y);

            for(int i = 0; i < lupperpipe.Count; i++)
            {
                g.DrawImage(lupperpipe[i].img, lupperpipe[i].X, lupperpipe[i].Y);
            }

            for (int i = 0; i < llowerpipe.Count; i++)
            {
                g.DrawImage(llowerpipe[i].img, llowerpipe[i].X, llowerpipe[i].Y);
            }
        }

        void DrawDubb(Graphics g)
        {
           Graphics g2 = Graphics.FromImage(off);
           DrawScene(g2);
           g.DrawImage(off, 0, 0);
        }
    }
}


