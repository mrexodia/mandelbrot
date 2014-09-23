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
        int recurseCount = 100;
        MandelColor color;
        double scale = 0.01;

        struct MandelState
        {
            public MandelState(Point midden, double scale)
            {
                this.midden = midden;
                this.scale = scale;
            }

            public Point midden;
            public double scale;
        }

        List<MandelState> stateList = new List<MandelState>();

        public Form1()
        {
            InitializeComponent();
            mandelPanel.Paint += mandelPanel_Paint;
            mandelPanel.MouseClick += mandelPanel_MouseClick;
            mandelPanel.MouseMove += mandelPanel_MouseMove;
            midden = new Point(mandelPanel.Width / 2 + 50, mandelPanel.Height / 2);
            color = new RandomColor();
        }

        void mandelPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                MandelState state = new MandelState(midden, scale);
                stateList.Add(state);
                double ratioMul = 2;
                Point click = mandelPanel.PointToClient(Cursor.Position);
                int dx = (int)(midden.X + (mandelPanel.Width / 2 - click.X * ratioMul));
                int dy = (int)(midden.Y + (mandelPanel.Height / 2 - click.Y * ratioMul));
                scale /= ratioMul;
                midden = new Point(midden.X + dx, midden.Y + dy);
            }
            else if(e.Button == MouseButtons.Right)
            {
                try
                {
                    scale = stateList.Last().scale;
                    midden = stateList.Last().midden;
                    stateList.Remove(stateList.Last());
                }
                catch
                {
                }
            }            
            mandelPanel.Invalidate();
        }

        void mandelPanel_MouseMove(object sender, MouseEventArgs e)
        {
            int w = mandelPanel.Width;
            int h = mandelPanel.Height;
            Point m = midden;
            MandelImage mandelImage = new MandelImage(w, h, m, scale, recurseCount);
            int n = mandelImage.getPixelMandel(e.X, e.Y);
            this.Text = String.Format("n: {0}", n);
        }

        void mandelPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int w = mandelPanel.Width;
            int h = mandelPanel.Height;
            Point m = midden;
            MandelImage mandelImage = new MandelImage(w, h, m, scale, recurseCount);
            Bitmap bitmap = mandelImage.create(color);
            g.DrawImage(bitmap, 0, 0);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(String.Format("10: {0}", kd(10)));
        }
    }
}
