using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ArchFinal
{
    public partial class Editor : Form
    {
        LocationFactory f;
        House house;
        LocationIF loc;
        StreamWriter writer;
        StreamReader reader;
        public Editor()
        {
            InitializeComponent();
            f = new LocationFactory();
            loadPrices();
            /*writer = File.CreateText("roof_prices.txt");
            writer = File.CreateText("foundation_prices.txt");
            writer = File.CreateText("floor_prices.txt");
            writer = File.CreateText("siding_prices.txt");
            writer = File.CreateText("door_prices.txt");
            writer = File.CreateText("window_prices.txt");
            writer = File.CreateText("paint_prices.txt");*/
        }

        public void loadPrices()
        {
            double price;
            AbsHouseParts part;
            reader = File.OpenText("roof_prices.txt");
            price = Convert.ToDouble(reader.ReadLine());
            part = Roof.createInstance(price);
            //reader = File.OpenText("foundation_prices.txt");
            //price = Convert.ToDouble(reader.ReadLine());
            //part = Foundation.createInstance(price);
        }

        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            switch (index)
            {
                case 0:
                    AbsHouseParts part = Roof.createInstance();
                    label4.Text = part.getPrice().ToString();
                    break;
                case 1:
                    part = Foundation.createInstance();
                    label4.Text = part.getPrice().ToString();
                    break;
                case 2:
                    part = Siding.createInstance();
                    label4.Text = part.getPrice().ToString();
                    break;
                case 3:
                    part = Floor.createInstance();
                    label4.Text = part.getPrice().ToString();
                    break;
                case 4:
                    part = Door.createInstance();
                    label4.Text = part.getPrice().ToString();
                    break;
                case 5:
                    part = Window.createInstance();
                    label4.Text = part.getPrice().ToString();
                    break;
                case 6:
                    //part = new Paint();
                    //label4.Text = part.getPrice().ToString();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double price = showDialog("Enter new price:", "Update Prices");
            if(textBox1.Text == "Oceanside")
            {
                writer = File.CreateText("oceanside.txt");
                writer.WriteLine(price);
            }
            if (textBox1.Text == "Country")
            {
                writer = File.CreateText("country.txt");
                writer.WriteLine(price);
            }
            if (textBox1.Text == "City")
            {
                writer = File.CreateText("city.txt");
                writer.WriteLine(price);
            }
            if (textBox1.Text == "Private Island")
            {
                writer = File.CreateText("private_island.txt");
                writer.WriteLine(price);
            }
            if (textBox1.Text == "Desert")
            {
                writer = File.CreateText("desert.txt");
                writer.WriteLine(price);
            }
            if (textBox1.Text == "Suburb")
            {
                writer = File.CreateText("suburb.txt");
                writer.WriteLine(price);
            }
            label14.Text = price.ToString();
            writer.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            loc = f.getLocation(text);
            label13.Text = text;
            label14.Text = loc.getPrice().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double price = showDialog("Enter new price:", "Update Prices");
            
           // writer.WriteLine(listBox1.Text + " " + price);
            label4.Text = price.ToString();
            switch (listBox1.SelectedIndex)
            {
                case 0:
                    //AbsHouseParts part = new Roof(price);
                    writer = File.CreateText("roof_prices.txt");
                    writer.WriteLine(price);
                    break;
                case 1:
                    writer = File.CreateText("foundation_prices.txt");
                    writer.WriteLine(price);
                    //part = new Siding(price);
                    break;
                case 2:
                    writer = File.CreateText("siding_prices.txt");
                    writer.WriteLine(price);
                    //part = new Foundation(price);
                    break;
                case 3:
                    writer = File.CreateText("floor_prices.txt");
                    writer.WriteLine(price);
                    //part = new Window(price);
                    break;
                case 4:
                    writer = File.CreateText("door_prices.txt");
                    writer.WriteLine(price);
                    //part = new Floor(price);
                    break;
                case 5:
                    writer = File.CreateText("window_prices.txt");
                    writer.WriteLine(price);
                    //part = new Door(price);
                    break;
                case 6:
                    //writer = File.CreateText("paint_prices.txt");
                   // writer.WriteLine(price);
                    //part = new Paint(price);
                    break;
                default:
                    break;
            }
            writer.Close();
        }

    public static double showDialog(string text, string title)
    {
        Form prompt = new Form();
        prompt.Width = 500;
        prompt.Height = 200;
        prompt.Text = title;
        Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
        TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
        Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
        confirmation.Click += (sender, e) => { prompt.Close(); };
        prompt.Controls.Add(confirmation);
        prompt.Controls.Add(textLabel);
        prompt.Controls.Add(textBox);
        prompt.ShowDialog();
        if (textBox.Text == "")
        {
            return 0;
        }
        return Convert.ToDouble(textBox.Text);
    }
    }
}
