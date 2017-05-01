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
        public Editor()
        {
            InitializeComponent();
            f = new LocationFactory();
            writer = File.CreateText("roof_prices.txt");
            writer = File.CreateText("foundation_prices.txt");
            writer = File.CreateText("floor_prices.txt");
            writer = File.CreateText("siding_prices.txt");
            writer = File.CreateText("door_prices.txt");
            writer = File.CreateText("window_prices.txt");
            writer = File.CreateText("paint_prices.txt");
        }

        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            writer.Close();
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
                    part = new Foundation();
                    label4.Text = part.getPrice().ToString();
                    break;
                case 2:
                    part = new Siding();
                    label4.Text = part.getPrice().ToString();
                    break;
                case 3:
                    part = new Floor();
                    label4.Text = part.getPrice().ToString();
                    break;
                case 4:
                    part = new Door();
                    label4.Text = part.getPrice().ToString();
                    break;
                case 5:
                    part = new Window();
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
            writer.WriteLine(label13.Text + " " + price);
            label14.Text = price.ToString();
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
            
            writer.WriteLine(listBox1.Text + " " + price);
            label4.Text = price.ToString();
            /*switch (listBox1.SelectedIndex)
            {
                case 0:
                    //AbsHouseParts part = new Roof(price);
                    writer.WriteLine(listBox1.Text + " " + price);
                    break;
                case 1:
                    //part = new Siding(price);
                    break;
                case 2:
                    //part = new Foundation(price);
                    break;
                case 3:
                    //part = new Window(price);
                    break;
                case 4:
                    //part = new Floor(price);
                    break;
                case 5:
                    //part = new Door(price);
                    break;
                case 6:
                    //part = new Paint(price);
                    break;
                default:
                    break;
            }*/
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
