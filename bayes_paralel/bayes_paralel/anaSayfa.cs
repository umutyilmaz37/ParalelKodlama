using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bayes_paralel
{
    public partial class anaSayfa : Form
    {
        public anaSayfa()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            kanserTahmin kt = new kanserTahmin();
            kt.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KategorizeEt k = new KategorizeEt();
            k.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yetkiliGiris v = new yetkiliGiris();
            v.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
