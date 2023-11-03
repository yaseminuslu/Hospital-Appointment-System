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
    public partial class hastarandevu : Form
    {
        public hastarandevu()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantısı bgl = new sqlbaglantısı();

        private void hastarandevu_Load(object sender, EventArgs e)
        {
            label3.Text = tc;
            //adsoyadekleme
            SqlCommand komut = new SqlCommand("Select hastaad,hastasoyad From hasta Where hastatc=@hastatc", bgl.baglantı());
            komut.Parameters.AddWithValue("@hastatc", label3.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0] +" "+ dr[1];
               
            }
            bgl.baglantı().Close();

            //randevugeçmişi
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From randevu Where hastatc=" + label3.Text,bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //poliklinikekle
            SqlCommand komut2 = new SqlCommand(" Select poliklinikad From poliklinik", bgl.baglantı());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox1.Items.Add(dr2[0]); 
            
            }
            bgl.baglantı().Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update randevu set durum=1,hastatc=@hastatc,hastasikayet=@hastasikayet where id=@id",bgl.baglantı());
            komut.Parameters.AddWithValue("@hastatc",label3.Text);
            komut.Parameters.AddWithValue("@hastasikayet",richTextBox1.Text);
            komut.Parameters.AddWithValue("@id",textBox1.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Randevu İşleminiz Alınmıştır.","Bilgi Mesajı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();

            SqlCommand komut3 = new SqlCommand("Select doktorad,doktorsoyad From doktor where doktorpoliklinik=@doktorpoliklinik", bgl.baglantı());
            komut3.Parameters.AddWithValue("@doktorpoliklinik", comboBox1.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read()) 
            {
                comboBox2.Items.Add(dr3[0] + " " + dr3[1]);

            
            }
            bgl.baglantı().Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From randevu where poliklinik='"+comboBox1.Text+"'"+"and doktor='"+comboBox2.Text+"'and durum=0", bgl.baglantı());
            da.Fill(dt);
            dataGridView2.DataSource = dt;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            hastabilgidüzenle frm = new hastabilgidüzenle();
            frm.tcno = label3.Text;
            frm.Show();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            hastarandevu.ActiveForm.Visible = false;
            girişseç frm = new girişseç();
            frm.Show();
        }
    }
}
