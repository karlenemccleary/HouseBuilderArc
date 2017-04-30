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
       
        LocationFactory f;
        House house;
        LocationIF loc;
        public Bitmap bitmap1;
        public Bitmap bitmap2;
        public bool pressedFirst;

        public Builder()
        {
            InitializeComponent();
            f = new LocationFactory();
            //house = new House();
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



        private void checkButton_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            loc = f.getLocation(text);
            label13.Text = text;
            label14.Text = loc.getPrice().ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            house = new Decorator(house, loc);
            label2.Text = house.getPrice().ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            house = new House();
        }

        private void panel_Click(object sender, EventArgs e)
        {
            if (sidingButton.Checked)
            {
                house.addPart(new Siding());
            }
            else if (roofButton.Checked)
            {
                house.addPart(new Roof());
            }
            else if (paintButton.Checked)
            {
                //house.addPart(new Paint());
            }
            else if (doorButton.Checked)
            {
                house.addPart(new Door());
            }
            else if (windowButton.Checked)
            {
                //house.addPart(new Window());
            }
            else if (floorButton.Checked)
            {
                house.addPart(new Floor());
            }
            label2.Text = house.getPrice().ToString();
        }
    }
}
