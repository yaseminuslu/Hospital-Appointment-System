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
    public partial class doktorpaneli : Form
    {
        public doktorpaneli()
        {
            InitializeComponent();
        }

        sqlbaglantısı bgl = new sqlbaglantısı();

        private void doktorpaneli_Load(object sender, EventArgs e)
        {
            //poliklinikekle
            SqlCommand komut2 = new SqlCommand("Select poliklinikad From poliklinik", bgl.baglantı());
            komut2.Parameters.AddWithValue("@poliklinikad", comboBox1.Text);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[0]);

            }
            bgl.baglantı().Close();

            //doktorekle
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From doktor", bgl.baglantı());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into doktor(doktorad,doktorsoyad,doktorpoliklinik,doktortc,doktorsifre)values(@doktorad,@doktorsoyad,@doktorpoliklinik,@doktortc,@doktorsifre)", bgl.baglantı());
            komut.Parameters.AddWithValue("@doktorad",textBox2.Text);
            komut.Parameters.AddWithValue("@doktorsoyad",textBox3.Text);
            komut.Parameters.AddWithValue("@doktorpoliklinik",comboBox1.Text);
            komut.Parameters.AddWithValue("@doktorsifre",textBox4.Text);
            komut.Parameters.AddWithValue("@doktortc",maskedTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Doktor Eklendi","Bilgi Mesajı",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from doktor where doktortc=@doktortc ",bgl.baglantı());
            komut.Parameters.AddWithValue("@doktortc",maskedTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Kayıt Silindi","Uyarı Mesajı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            comboBox1.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
           

           

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update doktor set doktorad=@doktorad,doktorsoyad=@doktorsoyad,doktorpoliklinik=@doktorpoliklinik,doktortc=@doktortc,doktorsifre=@doktorsifre",bgl.baglantı());
            komut.Parameters.AddWithValue("@doktorad",textBox2.Text);
            komut.Parameters.AddWithValue("@doktorsoyad", textBox3.Text);
            komut.Parameters.AddWithValue("@doktorsifre", textBox4.Text);
            komut.Parameters.AddWithValue("@doktorpoliklinik", comboBox1.Text);
            komut.Parameters.AddWithValue("@doktortc",maskedTextBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Güncelleme İşlemi Başarıyla Kaydedildi.","Bilgi Mesajı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
        }


    }
    }



