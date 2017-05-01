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
        Bitmap bmp;
        int startX;
        int startY;
        Color c;

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
            c = Color.White;
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

        /*private void Builder_Load(object sender, EventArgs e)
        {
            PictureBox pb1 = new PictureBox();
            pb1.ImageLocation = "roof.png";
            pb1.SizeMode = PictureBoxSizeMode.AutoSize;
        }*/

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

            else if (doorButton.Checked)
            {
                house.addPart(new Door());
            }
            else if (windowButton.Checked)
            {
                house.addPart(new Window());
            }
            else if (floorButton.Checked)
            {
                house.addPart(new Floor());
            }
            else if (foundationButton.Checked)
            {
                house.addPart(new Foundation());
                
            }
            label2.Text = house.getPrice().ToString();
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            pressedFirst = true;
            startX = e.X;
            startY = e.Y;
        }


        private void drawCode(Image img, int finalX, int finalY)
        {

            //create temp to old info
            Bitmap temp = new Bitmap(bitmap1);
            //set ups graphics to draw
            using (Graphics g = Graphics.FromImage(temp))
            {

                //had memory leak fixed it
                g.DrawImage(img, Math.Min(startX, finalX), Math.Min(startY, finalY), Math.Abs(finalX - startX), Math.Abs(finalY- startY));


            }
            //fixed memory leak
            bitmap2.Dispose();
            //set the second bitmap to temp
            bitmap2 = new Bitmap(temp);
            //make everything visible on screen
            this.panel.BackgroundImage = this.bitmap2;
            panel.BackgroundImageLayout = ImageLayout.None;
            //know memory leaked parnoid
            temp.Dispose();
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (pressedFirst)
            {
                //set the x and y for second set
                int finalX = e.X;
                int finalY = e.Y;
                if (sidingButton.Checked)
                {
                    house.addPart(new Siding());
                }
                else if (roofButton.Checked)
                {
                    //  house.addPart(new Foundation());
                    Image img = Image.FromFile("roof.png");
                    drawCode(img, finalX, finalY);
                }

                else if (doorButton.Checked)
                {
                    house.addPart(new Door());
                }
                else if (windowButton.Checked)
                {
                    house.addPart(new Window());
                }
                else if (floorButton.Checked)
                {
                    house.addPart(new Floor());
                }
                else if (foundationButton.Checked)
                {
                    //  house.addPart(new Foundation());
                    Image img = Image.FromFile("foundation.png");
                    drawCode(img, finalX, finalY);
                }
                label2.Text = house.getPrice().ToString();
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            //copy the second bitmap back to original
            bitmap1 = new Bitmap(bitmap2);
            //no longer dragging mouse
            pressedFirst = false;
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel1.BackColor = colorDialog1.Color;
                c = colorDialog1.Color;
            }
        }
    }
}
