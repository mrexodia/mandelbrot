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
        Point middle;
        int recurseCount = 100;
        MandelColor color;
        double scale = 0.01;
        Bitmap mandelBitmap;

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
            //register event handlers
            mandelPanel.Paint += mandelPanel_Paint;
            mandelPanel.MouseClick += mandelPanel_MouseClick;
            mandelPanel.MouseMove += mandelPanel_MouseMove;
            //initialize variables
            middle = new Point(mandelPanel.Width / 2 + 50, mandelPanel.Height / 2);
            color = new RandomColor();
            refreshImage();
            fillTextFields();
        }

        void refreshImage()
        {
            int w = mandelPanel.Width;
            int h = mandelPanel.Height;
            Point m = middle;
            MandelImage mandelImage = new MandelImage(w, h, m, scale, recurseCount);
            mandelBitmap = mandelImage.create(color);
        }

        void fillTextFields()
        {
            //fill text fields with default
            textBoxScale.Text = scale.ToString();
            textBoxMax.Text = recurseCount.ToString();
            textBoxMiddleX.Text = middle.X.ToString();
            textBoxMiddleY.Text = middle.Y.ToString();
        }

        void mandelPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MandelState state = new MandelState(middle, scale);
                stateList.Add(state);
                double ratioMul = 2;
                Point click = mandelPanel.PointToClient(Cursor.Position);
                int dx = (int)(middle.X + (mandelPanel.Width / 2 - click.X * ratioMul));
                int dy = (int)(middle.Y + (mandelPanel.Height / 2 - click.Y * ratioMul));
                scale /= ratioMul;
                middle = new Point(middle.X + dx, middle.Y + dy);
            }
            else if (e.Button == MouseButtons.Right)
            {
                try
                {
                    scale = stateList.Last().scale;
                    middle = stateList.Last().midden;
                    stateList.Remove(stateList.Last());
                }
                catch
                {
                    return;
                }
            }
            refreshImage();
            fillTextFields();
            mandelPanel.Invalidate();
        }

        void mandelPanel_MouseMove(object sender, MouseEventArgs e)
        {
            int w = mandelPanel.Width;
            int h = mandelPanel.Height;
            Point m = middle;
            MandelImage mandelImage = new MandelImage(w, h, m, scale, recurseCount);
            int n = mandelImage.getPixelMandel(e.X, e.Y);
            this.Text = String.Format("n: {0}", n);
        }

        void mandelPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(mandelBitmap, 0, 0);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            refreshImage();
            mandelPanel.Invalidate();
        }
    }
}
