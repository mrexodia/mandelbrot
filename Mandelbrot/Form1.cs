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
        MandelPoint middle;
        MandelColor color;
        MandelImage mandelImage;
        Bitmap mandelBitmap;
        int maxLoop = 100;
        double scale = 0.01;        
        List<MandelState> stateList = new List<MandelState>();

        public Form1()
        {
            InitializeComponent();
            //register event handlers
            mandelPanel.Paint += mandelPanel_Paint;
            mandelPanel.MouseClick += mandelPanel_MouseClick;
            mandelPanel.MouseMove += mandelPanel_MouseMove;
            //initialize variables
            middle = new MandelPoint();
            color = new BlueAlpha();
            refreshImage();
            fillTextFields();
        }

        //method to regenerate the bitmap to display
        void refreshImage()
        {
            mandelImage = new MandelImage(mandelPanel.Width, mandelPanel.Height, middle, scale, maxLoop);
            mandelBitmap = mandelImage.create(color);
            mandelPanel.Invalidate();
        }

        //method to update the text fields to the current values
        void fillTextFields()
        {
            textBoxScale.Text = scale.ToString();
            textBoxMax.Text = maxLoop.ToString();
            textBoxMiddleX.Text = middle.a.ToString();
            textBoxMiddleY.Text = middle.b.ToString();
        }

        void mandelPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //zoom in
            {
                MandelState state = new MandelState(middle, scale, maxLoop);
                stateList.Add(state);
                Point click = mandelPanel.PointToClient(Cursor.Position);
                middle = mandelImage.pixelToMandelPoint(click.X, click.Y);
                scale /= 2;
            }
            else if (e.Button == MouseButtons.Right) //zoom out
            {
                try
                {
                    scale = stateList.Last().scale;
                    middle = stateList.Last().middle;
                    maxLoop = stateList.Last().maxLoop;
                    stateList.Remove(stateList.Last());
                }
                catch
                {
                    return; //don't refresh when there is no previous state
                }
            }
            refreshImage();
            fillTextFields();
        }

        void mandelPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Point click = mandelPanel.PointToClient(Cursor.Position);
            MandelPoint mandelPoint = mandelImage.pixelToMandelPoint(click.X, click.Y);
            int n = mandelImage.mandelPointToNumber(mandelPoint);
            this.Text = String.Format("({0}, {1}): {2}", mandelPoint.a, mandelPoint.b, n);
        }

        void mandelPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(mandelBitmap, 0, 0);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                scale = double.Parse(textBoxScale.Text);
                maxLoop = int.Parse(textBoxMax.Text);
                middle = new MandelPoint(double.Parse(textBoxMiddleX.Text), double.Parse(textBoxMiddleY.Text));
                refreshImage();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid format used!", "Error");
            }
        }
    }
}
