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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Builder frm = new Builder();
            frm.Show();
            frm.Activate();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Editor frm = new Editor();
            frm.Show();
            frm.Activate();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
