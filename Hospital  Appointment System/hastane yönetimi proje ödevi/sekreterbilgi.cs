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
    public partial class sekreterbilgi : Form
    {
        public sekreterbilgi()
        {
            InitializeComponent();
        }
        public string tcnumara;
        sqlbaglantısı bgl = new sqlbaglantısı();

        private void button5_Click(object sender, EventArgs e)
        {
            poliklinikpaneli frm = new poliklinikpaneli();
            frm.Show();
          
        }

        private void sekreterbilgi_Load(object sender, EventArgs e)
        {
            label3.Text = tcnumara;

            //adsoyad
            SqlCommand komut1 = new SqlCommand("Select sekreteradsoyad From sekreter where sekretertc=@sekretertc", bgl.baglantı());
            komut1.Parameters.AddWithValue("@sekretertc", label3.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                label4.Text = dr1[0].ToString();

            }
            bgl.baglantı().Close();

            //poliklinik
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select poliklinikad From poliklinik", bgl.baglantı());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            //doktorekle
            DataTable dt2 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select (doktorad+ ' '+ doktorsoyad) as 'Doktorlar',doktorpoliklinik,doktortc,doktorsifre From doktor", bgl.baglantı());
            da1.Fill(dt2);
            dataGridView2.DataSource = dt2;


             //poliklinikekle
            SqlCommand  komut2=new  SqlCommand("Select poliklinikad From poliklinik",bgl.baglantı());
            komut2.Parameters.AddWithValue("@poliklinikad", comboBox1.Text);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {
            comboBox1.Items.Add(dr2[0]);
            
            }
            bgl.baglantı().Close();

            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into randevu (tarih,saat,poliklinik,doktor) values (@tarih,@saat,@poliklinik,@doktor)",bgl.baglantı());
            komut.Parameters.AddWithValue("@tarih",maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@saat",maskedTextBox2.Text);
            komut.Parameters.AddWithValue("@poliklinik",comboBox1.Text);
            komut.Parameters.AddWithValue("@doktor",comboBox2.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("İşlem Başarıyla Gerçekleştirildi","Bilgi Mesajı",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //doktorekle
            comboBox2.Items.Clear();
            SqlCommand komut3 = new SqlCommand(" Select doktorad,doktorsoyad From doktor Where doktorpoliklinik=@doktorpoliklinik", bgl.baglantı());
            komut3.Parameters.AddWithValue("@doktorpoliklinik", comboBox1.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                comboBox2.Items.Add(dr3[0] + " " + dr3[1]);

            }
            bgl.baglantı().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into duyuru (duyuru)values(@duyuru)",bgl.baglantı());
            komut.Parameters.AddWithValue("@duyuru",richTextBox1.Text);
           komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
            
            }

        private void button4_Click(object sender, EventArgs e)
        {
            doktorpaneli frm=new doktorpaneli();
            frm.Show();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            randevulistesi frm = new randevulistesi();
            frm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            duyurular frm = new duyurular();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            sekreterbilgi.ActiveForm.Visible = false;
            girişseç frm=new girişseç();
            frm.Show();
            
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
           
            
          
        }
        }
 
}

