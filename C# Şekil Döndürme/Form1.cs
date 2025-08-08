using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace ucgen
{
    public partial class Form1 : Form
    {
        float alfa = 0;

        public Form1()
        {
            InitializeComponent();
            OpenGlControl.InitializeContexts();
            // OpenGL ilk işlemler
            Gl.glClearColor(0.0f, 0.0f, 0.5f, 0.0f);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0.0, 1.0, 0.0, 1.0, -1.0, 1.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MyPaint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glShadeModel(Gl.GL_SMOOTH);

            //Gl.glTranslatef(x,y,z);
            Gl.glPushMatrix();
                Gl.glTranslatef(0.5f, 0.5f, 0);  // Geri alma
                Gl.glRotatef(alfa, 0, 0, 1);
                Gl.glTranslatef(-0.5f, -0.5f, 0);  // Merkez çakıştırma
                Gl.glBegin(Gl.GL_TRIANGLES);
                    Gl.glColor3f(1.0f, 0.0f, 0.0f);   // Kırmızı
                    Gl.glVertex3f(0.5f, 1.0f, 0.0f);

                    Gl.glColor3f(1.0f, 1.0f, 0.0f);  // Sarı
                    Gl.glVertex3f(0.0f, 0.0f, 0.0f);

                    Gl.glColor3f(0.0f, 0.0f, 0.3f);  // Mavi
                    Gl.glVertex3f(1.0f, 0.0f, 0.0f);
                Gl.glEnd();
            Gl.glPopMatrix();
        }

        private void OpenGlControl_Load(object sender, EventArgs e)
        {

        }

        private void buttonDondur_Click(object sender, EventArgs e)
        {
            alfa = (alfa+5) % 360;
            OpenGlControl.Refresh();
        }

        private void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                alfa = (alfa + 5) % 360;
            if (e.KeyCode == Keys.D)
                alfa = (alfa - 5) % 360;
            OpenGlControl.Refresh();
        }
    }
}
