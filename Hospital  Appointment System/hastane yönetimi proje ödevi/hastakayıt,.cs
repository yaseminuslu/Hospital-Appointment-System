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
    public partial class hastakayıt_ : Form
    {
        public hastakayıt_()
        {
            InitializeComponent();
        }

        sqlbaglantısı bgl = new sqlbaglantısı();

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into hasta(hastaad,hastasoyad,hastatc,hastatelefon,hastasifre,hastacinsiyet)values (@hastaad,@hastasoyad,@hastatc,@hastatelefon,@hastasifre,@hastacinsiyet)",bgl.baglantı());
            komut.Parameters.AddWithValue("@hastaad", textBox1.Text);
            komut.Parameters.AddWithValue("@hastasoyad", textBox2.Text);
            komut.Parameters.AddWithValue("@hastatc", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@hastatelefon", maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@hastasifre", textBox3.Text);
            komut.Parameters.AddWithValue("@hastacinsiyet", comboBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Kayıt İşlemi Gerçekleştirilmiştir Şifreniz: " + textBox3.Text ,"Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
