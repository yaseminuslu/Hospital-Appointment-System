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
    public partial class doktorbilgi : Form
    {
        public doktorbilgi()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();
        public string tc;
        private void button1_Click(object sender, EventArgs e)
        {
            doktorbilgidüzenle frm = new doktorbilgidüzenle();
            frm.tc = label3.Text;
            frm.Show();
        }

        private void doktorbilgi_Load(object sender, EventArgs e)
        {
            
            label3.Text = tc;

            //adsoyadekle
            SqlCommand komut = new SqlCommand("Select doktorad,doktorsoyad From doktor where doktortc=@doktortc",bgl.baglantı());
            komut.Parameters.AddWithValue("doktortc",label3.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                label4.Text = dr[0] + " " + dr[1];
            }
            bgl.baglantı().Close();

            //randevular
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From randevu where doktor='"+label4.Text+"'",bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            duyurular frm = new duyurular();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            richTextBox1.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            doktorbilgi.ActiveForm.Visible = false;
            girişseç frm = new girişseç();
            frm.Show();
        }
    }
}
