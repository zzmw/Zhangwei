using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace test
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        int n;
        double x0;
        double y0;
        double leng;
        double th;
        

        public Form1()
        {
            n = 10;
            x0 = 160;
            y0 = 300;
            leng = 100;
            th = -Math.PI / 2;
            graphics = this.CreateGraphics();
            
            
            InitializeComponent();
            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            this.graphics.Clear(Color.White);
            if (graphics == null)
                graphics = this.CreateGraphics();
            drawCayleyTree(n, x0, y0,leng, th);
        }

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0)
                return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);

        }

        void drawLine(double x0, double y0, double x1, double y1)
        {
            graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            n = tb.Value;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.graphics.Clear(Color.White);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            leng = tb.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            th = tb.Value * Math.PI / 180;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
            return;
        }
    }
}
