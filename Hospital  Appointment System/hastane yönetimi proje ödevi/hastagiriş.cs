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
    public partial class hastagiriş : Form
    {
        public hastagiriş()
        {
            InitializeComponent();
        }

        sqlbaglantısı bgl =new sqlbaglantısı();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From hasta Where hastatc=@hastatc and hastasifre=@hastasifre", bgl.baglantı());
            komut.Parameters.AddWithValue("@hastatc", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("hastasifre", textBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                hastarandevu frm = new hastarandevu();
                frm.tc = maskedTextBox1.Text;
                frm.Show();
                this.Hide();
              
            }
            else 
            {
                MessageBox.Show("Hatalı TC Kimlik No & Şifre");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hastakayıt_ frm = new hastakayıt_();
            frm.Show();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hastagiriş.ActiveForm.Visible = false;
            girişseç frm = new girişseç();
            frm.Show();
        }
    }
}
