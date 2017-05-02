using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
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
        StreamReader reader;

        public Builder()
        {
            InitializeComponent();
            f = new LocationFactory();
            loadPrices();
            house = new House();
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

        public void loadPrices()
        {
            double price;
            AbsHouseParts part;
            reader = File.OpenText("roof_prices.txt");
            price = Convert.ToDouble(reader.ReadLine());
            part = Roof.createInstance(price);
            roofLabel.Text = price.ToString();
            reader = File.OpenText("foundation_prices.txt");
            price = Convert.ToDouble(reader.ReadLine());
            part = Foundation.createInstance(price);
            foundationLabel.Text = price.ToString();
            reader = File.OpenText("siding_prices.txt");
            price = Convert.ToDouble(reader.ReadLine());
            part = Siding.createInstance(price);
            sidingLabel.Text = price.ToString();
            reader = File.OpenText("door_prices.txt");
            price = Convert.ToDouble(reader.ReadLine());
            part = Door.createInstance(price);
            doorLabel.Text = price.ToString();
            reader = File.OpenText("window_prices.txt");
            price = Convert.ToDouble(reader.ReadLine());
            part = Window.createInstance(price);
            windowLabel.Text = price.ToString();
            reader = File.OpenText("floor_prices.txt");
            price = Convert.ToDouble(reader.ReadLine());
            part = Floor.createInstance(price);
            floorLabel.Text = price.ToString();
            //reader = File.OpenText("paint_prices.txt");
            // price = Convert.ToDouble(reader.ReadLine());
            //part = Paint.createInstance(price);
            //label8.Text = price.ToString();
            reader = File.OpenText("oceanside.txt");
            price = Convert.ToDouble(reader.ReadLine());
            loc = Oceanside.createInstance(price);
            reader = File.OpenText("city.txt");
            price = Convert.ToDouble(reader.ReadLine());
            loc = City.createInstance(price);
            reader = File.OpenText("desert.txt");
            price = Convert.ToDouble(reader.ReadLine());
            loc = Desert.createInstance(price);
            reader = File.OpenText("private_island.txt");
            price = Convert.ToDouble(reader.ReadLine());
            loc = PrivateIsland.createInstance(price);
            reader = File.OpenText("country.txt");
            price = Convert.ToDouble(reader.ReadLine());
            loc = Country.createInstance(price);
            reader = File.OpenText("suburb.txt");
            price = Convert.ToDouble(reader.ReadLine());
            loc = Suburb.createInstance(price);
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
            bitmap1.Dispose();
            bitmap1 = new Bitmap(panel.Width, panel.Height);
            //make everything visible on screen
            this.panel.BackgroundImage = this.bitmap1;
            panel.BackgroundImageLayout = ImageLayout.None;

        }

        private void panel_Click(object sender, EventArgs e)
        {
            if (sidingButton.Checked)
            {
                house.addPart(Siding.createInstance());
            }
            else if (roofButton.Checked)
            {
                house.addPart(Roof.createInstance());
            }

            else if (doorButton.Checked)
            {
                house.addPart(Door.createInstance());
            }
            else if (windowButton.Checked)
            {
                house.addPart(Window.createInstance());
            }
            else if (floorButton.Checked)
            {
                house.addPart(Floor.createInstance());
            }
            else if (foundationButton.Checked)
            {
                house.addPart(Foundation.createInstance());
                
            }
            label2.Text = house.getPrice().ToString();
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            pressedFirst = true;
            startX = e.X;
            startY = e.Y;
        }


        private void drawCode(Image img, int finalX, int finalY, bool rec)
        {

            //create temp to old info
            Bitmap temp = new Bitmap(bitmap1);
            //set ups graphics to draw
            using (Graphics g = Graphics.FromImage(temp))
            {

                //had memory leak fixed it
                g.DrawImage(img, Math.Min(startX, finalX), Math.Min(startY, finalY), Math.Abs(finalX - startX), Math.Abs(finalY- startY));
                if(rec)
                {
                    Brush brush = new SolidBrush(Color.FromArgb(200,c));
                    g.FillRectangle(brush, Math.Min(startX, finalX), Math.Min(startY, finalY), Math.Abs(finalX - startX), Math.Abs(finalY - startY));
                }

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
                    //house.addPart(new Siding());
                    Image img = Image.FromFile("siding.png");
                    drawCode(img, finalX, finalY, true);
                }
                else if (roofButton.Checked)
                {
                    //  house.addPart(new Foundation());
                    Image img = Image.FromFile("roof.png");
                    drawCode(img, finalX, finalY, false);
                }

                else if (doorButton.Checked)
                {
                    //  house.addPart(new Door());
                    Image img = Image.FromFile("door.png");
                    drawCode(img, finalX, finalY, true);
                }
                else if (windowButton.Checked)
                {
                    // house.addPart(new Window());
                    Image img = Image.FromFile("window.png");
                    drawCode(img, finalX, finalY, false);
                }
                else if (floorButton.Checked)
                {
                    // house.addPart(new Floor());
                    Image img = Image.FromFile("floor.png");
                    drawCode(img, finalX, finalY, false);
                }
                else if (foundationButton.Checked)
                {
                    //  house.addPart(new Foundation());
                    Image img = Image.FromFile("foundation.png");
                    drawCode(img, finalX, finalY, false);
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
