using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace hastane_yönetimi_proje_ödevi
{
    class sqlbaglantısı
    {
        public SqlConnection baglantı()
        {
            SqlConnection baglan = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=hastaneyönetimi;Integrated Security=True");
       baglan.Open();
       return baglan;
        }
    }
}
