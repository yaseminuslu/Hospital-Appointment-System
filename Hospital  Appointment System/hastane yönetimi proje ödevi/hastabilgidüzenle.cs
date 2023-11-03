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
    public partial class hastabilgidüzenle : Form
    {
        public hastabilgidüzenle()
        {
            InitializeComponent();
        }

        public string tcno;
        sqlbaglantısı bgl = new sqlbaglantısı();
        private void hastabilgidüzenle_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Text = tcno;
            SqlCommand komut = new SqlCommand("Select * From hasta where hastatc=@hastatc", bgl.baglantı());
            komut.Parameters.AddWithValue("hastatc", maskedTextBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[5].ToString();
                maskedTextBox2.Text = dr[4].ToString();
                comboBox1.Text = dr[6].ToString();
            }
            bgl.baglantı().Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update hasta set hastaad=@hastaad,hastasoyad=@hastasoyad,hastatelefon=@hastatelefon,hastasifre=@hastasifre,hastacinsiyet=@hastacinsiyet where  hastatc=@hastatc", bgl.baglantı());
            komut2.Parameters.AddWithValue("hastaad", textBox1.Text);
            komut2.Parameters.AddWithValue("hastasoyad", textBox2.Text);
            komut2.Parameters.AddWithValue("hastatelefon", maskedTextBox2.Text);
            komut2.Parameters.AddWithValue("hastasifre", textBox3.Text);
            komut2.Parameters.AddWithValue("hastacinsiyet", comboBox1.Text);
            komut2.Parameters.AddWithValue("hastatc", maskedTextBox1.Text);
            komut2.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Bilgileriniz Güncellenmiştir.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
