using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane_yönetimi_proje_ödevi
{
    public partial class girişpaneli : Form
    {
        public girişpaneli()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            girişseç frm =new girişseç();
            frm.Show();
            this.Hide();
        }
    }
}
