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
    public partial class sekretergiriş : Form
    {
        public sekretergiriş()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl=new sqlbaglantısı();

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("Select * From sekreter where sekretertc=@sekretertc and sekretersifre=@sekretersifre", bgl.baglantı());
            komut.Parameters.AddWithValue("@sekretertc", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@sekretersifre", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                sekreterbilgi frm = new sekreterbilgi();
                frm.tcnumara = maskedTextBox1.Text;
                frm.Show();
                this.Hide();
            
            }
         
            else

            {
            MessageBox.Show("Hatalı TC Kimlik NO & Şifre");
            
            }
            bgl.baglantı().Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sekretergiriş.ActiveForm.Visible = false;
            girişseç frm = new girişseç();
            frm.Show();
        }
    }
}
