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
    public partial class doktorbilgidüzenle : Form
    {
        public doktorbilgidüzenle()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();
        public string tc;
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update doktor set doktorad=@doktorad,doktorsoyad=@doktorsoyad,doktorpoliklinik=@doktorpoliklinik,doktorsifre=@doktorsifre where doktortc=@doktortc", bgl.baglantı());
            komut.Parameters.AddWithValue("@doktorad",textBox1.Text);
            komut.Parameters.AddWithValue("@doktorsoyad",textBox2.Text);
            komut.Parameters.AddWithValue("@doktorpoliklinik",comboBox1.Text);
            komut.Parameters.AddWithValue("@doktortc",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@doktorsifre",textBox3.Text);
            komut.ExecuteNonQuery();
            
            bgl.baglantı().Close();
           MessageBox.Show("Bilgileriniz Kaydedilmiştir.","Bilgi Mesajı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void doktorbilgidüzenle_Load(object sender, EventArgs e)
        {
            //poliklinikekle
            SqlCommand komut2 = new SqlCommand(" Select poliklinikad From poliklinik", bgl.baglantı());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[0]);

            }
            bgl.baglantı().Close();

            maskedTextBox1.Text = tc;
            SqlCommand komut = new SqlCommand("Select * From doktor where doktortc=@doktortc",bgl.baglantı());
            komut.Parameters.AddWithValue("@doktortc",maskedTextBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
                comboBox1.Text = dr[3].ToString();
                textBox3.Text = dr[5].ToString();
            
            }
            bgl.baglantı().Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
