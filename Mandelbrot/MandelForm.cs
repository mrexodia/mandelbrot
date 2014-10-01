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
    public partial class MandelForm : Form
    {
        MandelPoint middle;
        MandelImage mandelImage;
        Bitmap mandelBitmap;
        int maxLoop = 100;
        double scale = 0.01;
        List<MandelState> stateList = new List<MandelState>(); // list to save textbox-settings
        List<MandelColor> colorList = new List<MandelColor>(); // list for all possible colorfilters

        public MandelForm()
        {
            InitializeComponent();

            //add color filters
            colorList.Add(new RandomColor());
            colorList.Add(new BlueAlpha());
            colorList.Add(new RedGreenBlue());
            colorList.Add(new Fire());
            foreach (MandelColor color in colorList)
                comboBoxColors.Items.Add(color.ToString());
            comboBoxColors.SelectedItem = comboBoxColors.Items[0];

            //initialize variables
            middle = new MandelPoint(0, 0);
            refreshImage();
            fillTextFields();

            //register event handlers
            mandelPanel.Paint += mandelPanel_Paint;
            mandelPanel.MouseClick += mandelPanel_MouseClick;
            mandelPanel.MouseMove += mandelPanel_MouseMove;
            comboBoxColors.SelectedIndexChanged += comboBoxColors_SelectedIndexChanged;
        }

        // refreshes the image when using combobox
        void comboBoxColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshImage();
        }

        //method to regenerate the bitmap to display
        void refreshImage()
        {
            mandelImage = new MandelImage(mandelPanel.Width, mandelPanel.Height, middle, scale, maxLoop);
            mandelBitmap = mandelImage.create(colorList[comboBoxColors.SelectedIndex]);
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
                //add current statee to list
                MandelState state = new MandelState(middle, scale, maxLoop);
                stateList.Add(state);

                //calculate new middle + zoom
                middle = mandelImage.pixelToMandelPoint(e.X, e.Y);
                scale /= 2;
            }
            else if (e.Button == MouseButtons.Right) //zoom out
            {
                if (stateList.Count == 0)
                    return; //don't refresh when there is no previous state

                // loads the previous settings in textfields
                scale = stateList.Last().scale;
                middle = stateList.Last().middle;
                maxLoop = stateList.Last().maxLoop;
                stateList.Remove(stateList.Last());
            }
            refreshImage();
            fillTextFields();
        }

        void mandelPanel_MouseMove(object sender, MouseEventArgs e)
        {
            // display current position in graph
            MandelPoint mandelPoint = mandelImage.pixelToMandelPoint(e.X, e.Y);
            int n = mandelImage.mandelPointToNumber(mandelPoint);
            this.Text = String.Format("({0}, {1}): {2}", mandelPoint.a, mandelPoint.b, n);
        }

        // drawing the actual mandelbrot
        void mandelPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(mandelBitmap, 0, 0);
        }

        // method for adjusting settings when clicking 'refresh'
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                scale = double.Parse(textBoxScale.Text);
                maxLoop = int.Parse(textBoxMax.Text);
                middle = new MandelPoint(double.Parse(textBoxMiddleX.Text), double.Parse(textBoxMiddleY.Text));
                refreshImage();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid format used!", "Error"); // in case input is not a number
            }
        }

        // methods for examples
        private void buttonTeeth_Click(object sender, EventArgs e)
        {
            scale = 6.103515625E-07;
            maxLoop = 1000;
            middle = new MandelPoint(-1.63213623046875, -3.662109375E-06);
            comboBoxColors.SelectedItem = comboBoxColors.Items[0];
            fillTextFields();
            refreshImage();
        }

        private void buttonSpace_Click(object sender, EventArgs e)
        {
            scale = 3.0517578125E-07;
            maxLoop = 1000;
            middle = new MandelPoint(-1.6320947265625, -4.7607421875E-05);
            comboBoxColors.SelectedItem = comboBoxColors.Items[1];
            fillTextFields();
            refreshImage();
        }
    }
}
