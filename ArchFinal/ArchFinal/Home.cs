using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ArchFinal
{
    public partial class Home : Form
    {
        ReadWriteLock rwl;
        Thread editor;
        Thread builder;
        public Home()
        {
            InitializeComponent();
            rwl = new ReadWriteLock();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Builder frm = new Builder();
            frm.Show();
            frm.Activate();
            builder = new Thread(new ThreadStart(frm.loadPrices));
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Editor frm = new Editor();
            frm.Show();
            frm.Activate();
            editor = new Thread(new ThreadStart(frm.loadPrices));
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}
