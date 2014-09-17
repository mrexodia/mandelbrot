using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        Point midden;
        double scale = 0.007;

        public Form1()
        {
            InitializeComponent();
            mandelPanel.Paint += mandelPanel_Paint;
            mandelPanel.MouseMove += mandelPanel_MouseMove;
        }

        void mandelPanel_MouseMove(object sender, MouseEventArgs e)
        {
            int w = mandelPanel.Width;
            int h = mandelPanel.Height;
            Point m = new Point(w / 2, h / 2);
            m.X += 50;
            MandelImage mandelImage = new MandelImage(w, h, m, scale);
            int n = mandelImage.getPixelNumber(e.X, e.Y);
            this.Text = String.Format("n: {0}", n);
        }

        void mandelPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int w = mandelPanel.Width;
            int h = mandelPanel.Height;
            Point m = new Point(w / 2, h / 2);
            m.X += 50;
            MandelImage mandelImage = new MandelImage(w, h, m, scale);
            Bitmap bitmap = mandelImage.create();
            g.DrawImage(bitmap, 0, 0);
        }
    }
}
