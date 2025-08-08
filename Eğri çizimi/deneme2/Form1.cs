using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace deneme2
{
    public partial class Form1 : Form
    {
        public Form1() { 
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            Paint += Form1_Paint;

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
                
            Pen Black = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(Black, 250, 0, 250, 500);
            e.Graphics.DrawLine(Black, 0, 250, 500, 250);

        }
        void Çizim()
        {
            try
            {
            Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen Red = new Pen(Color.Red, 1);
            Brush BLUE = new SolidBrush(Color.Blue);
            float StartX = Convert.ToSingle(Point0X.Text);
            float StartY = Convert.ToSingle(Point0Y.Text);
            float CNTR1X = Convert.ToSingle(Point1X.Text);
            float CNTR1Y = Convert.ToSingle(Point1Y.Text);
            float CNTR2X = Convert.ToSingle(Point2X.Text);
            float CNTR2Y = Convert.ToSingle(Point2Y.Text);
            float ENDX   = Convert.ToSingle(Point3X.Text);
            float ENDY   = Convert.ToSingle(Point3Y.Text);
            graphicsObj.FillRectangle(BLUE, 247 + (StartX * 25), 247 - (StartY * 25), 6, 6);
            graphicsObj.FillRectangle(BLUE, 247 + (CNTR1X * 25), 247 - (CNTR1Y * 25), 6, 6);
            graphicsObj.FillRectangle(BLUE, 247 + (CNTR2X * 25), 247 - (CNTR2Y * 25), 6, 6);
            graphicsObj.FillRectangle(BLUE, 247 + (ENDX * 25), 247 - (ENDY * 25), 6, 6);
            double dx = (StartX * Math.Pow(1 - 0, 3)) + (3 * CNTR1X * 0 * Math.Pow(1 - 0, 2)) + (3 * CNTR2X * Math.Pow(0, 2) * (1 - 0)) + (ENDX * Math.Pow(0, 3));
            double dy = (StartY * Math.Pow(1 - 0, 3)) + (3 * CNTR1Y * 0 * Math.Pow(1 - 0, 2)) + (3 * CNTR2Y * Math.Pow(0, 2) * (1 - 0)) + (ENDY * Math.Pow(0, 3));
            for (double i = 0.02; i <= 1.0; i += 0.02)
             {
                double dx2= (StartX * Math.Pow(1 - i, 3)) + (3 * CNTR1X * i * Math.Pow(1 - i, 2)) + (3 * CNTR2X * Math.Pow(i, 2) * (1 - i)) + (ENDX * Math.Pow(i, 3));
                double dy2 = (StartY * Math.Pow(1 - i, 3)) + (3 * CNTR1Y * i * Math.Pow(1 - i, 2)) + (3 * CNTR2Y * Math.Pow(i, 2) * (1 - i)) + (ENDY * Math.Pow(i, 3));
                float fx = Convert.ToSingle(dx);
                float fy = Convert.ToSingle(dy);
                float fx2 = Convert.ToSingle(dx2);
                float fy2 = Convert.ToSingle(dy2); 
                graphicsObj.DrawLine(Red, 250 + (fx * 25), 250 - (fy * 25), 250 + (fx2 * 25), 250 - (fy2 * 25));
                dx = dx2; dy = dy2;
             }
            }
            catch (Exception HATA)
            {
                MessageBox.Show("HATA:" + HATA.Message, "HATA BULUNDU!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }
        private void ÇİZ_Click(object sender, EventArgs e)
        { 
            
           Çizim();
             
        }
    }
}