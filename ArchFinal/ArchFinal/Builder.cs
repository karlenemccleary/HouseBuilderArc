using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchFinal
{
    public partial class Builder : Form
    {
        public Bitmap bitmap1;
        public Bitmap bitmap2;
        public bool pressedFirst;

        public Builder()
        {
            InitializeComponent();
            //set the bitmap for drawing to panel size
            bitmap1 = new Bitmap(panel.Width, panel.Height);
            bitmap2 = new Bitmap(panel.Width, panel.Height);
            //checks to make sure mouse is pressed for dragging
            pressedFirst = false;

            //stops flickering
            typeof(Panel).InvokeMember("DoubleBuffered",
               BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
               null, panel, new object[] { true });
        }

        private void Builder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (sidingButton.Checked)
            {
                Bitmap temp = new Bitmap(bitmap1);
                //set ups graphics to draw
                using (Graphics g = Graphics.FromImage(temp))
                {
                    
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            //copy the second bitmap back to original
            bitmap1 = new Bitmap(bitmap2);
            //no longer dragging mouse
            pressedFirst = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(pressedFirst)
            {

            }
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if(sidingButton.Checked)
            {

            }

        }
    }
}
