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
            mandelPanel.MouseClick += mandelPanel_MouseClick;
            midden = new Point(mandelPanel.Width / 2 + 50, mandelPanel.Height / 2);
        }

        void mandelPanel_MouseClick(object sender, MouseEventArgs e)
        {
            double ratioMul = 2;
            Point click = mandelPanel.PointToClient(Cursor.Position);
            int dx = (int)(midden.X + (mandelPanel.Width / 2 - click.X * ratioMul));
            int dy = (int)(midden.Y + (mandelPanel.Height / 2 - click.Y * ratioMul));
            scale /= ratioMul;
            midden = new Point(midden.X + dx, midden.Y + dy);
            mandelPanel.Invalidate();
        }

        void mandelPanel_MouseMove(object sender, MouseEventArgs e)
        {
            int w = mandelPanel.Width;
            int h = mandelPanel.Height;
            Point m = midden;
            MandelImage mandelImage = new MandelImage(w, h, m, scale);
            int n = mandelImage.getPixelNumber(e.X, e.Y);
            this.Text = String.Format("n: {0}", n);
        }

        void mandelPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int w = mandelPanel.Width;
            int h = mandelPanel.Height;
            Point m = midden;
            MandelImage mandelImage = new MandelImage(w, h, m, scale);
            Bitmap bitmap = mandelImage.create();
            g.DrawImage(bitmap, 0, 0);
        }
    }
}
