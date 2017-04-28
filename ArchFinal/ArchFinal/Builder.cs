using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArchFinal
{
    public partial class Builder : Form
    {
        LocationFactory f;
        HouseIF house;
        LocationIF loc;
        public Builder()
        {
            InitializeComponent();
            f = new LocationFactory();
        }

        private void Builder_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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
            Decorator d = new Decorator(house, loc);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            house = new House();
        }
    }
}
