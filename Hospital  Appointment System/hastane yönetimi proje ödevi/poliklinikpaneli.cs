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
    public partial class poliklinikpaneli : Form
    {
        public poliklinikpaneli()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl=new sqlbaglantısı();

        private void poliklinikpaneli_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("Select* From poliklinik",bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut=new SqlCommand("insert into poliklinik (poliklinikad)values(@poliklinikad)",bgl.baglantı());
            komut.Parameters.AddWithValue("@poliklinikad",textBox2.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Poliklinik Eklendi","Bilgi Mesajı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from poliklinik where poliklinikad=@poliklinikad ", bgl.baglantı());
            komut.Parameters.AddWithValue("@poliklinikad",textBox2.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Kayıt Silindi", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update doktor set poliklinikad=@poliklinikad", bgl.baglantı());
            komut.Parameters.AddWithValue("@poliklinikad", textBox2.Text);
           komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Güncelleme İşlemi Başarıyla Kaydedildi.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
