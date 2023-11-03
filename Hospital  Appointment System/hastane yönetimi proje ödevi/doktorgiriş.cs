using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hastane_yönetimi_proje_ödevi
{
    public partial class doktorgiriş : Form
    {
        public doktorgiriş()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From doktor where doktortc=@doktortc and doktorsifre=@doktorsifre",bgl.baglantı());
            komut.Parameters.AddWithValue("@doktortc",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@doktorsifre",textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                doktorbilgi frm = new doktorbilgi();
                frm.tc = maskedTextBox1.Text;
                frm.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Hatalı TC Kimlik No & Şifre","Uyarı Mesajı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            doktorgiriş.ActiveForm.Visible = false;
            girişseç frm = new girişseç();
            frm.Show();
        }
    }
}
