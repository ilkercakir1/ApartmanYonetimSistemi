using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//sql kütüphanesi

namespace ApartmanYönetimSistemi.DL
{
    class SqlConn
    {

        public SqlConnection baglan()
        {
            SqlConnection baglanti = new SqlConnection("Data Source=.; initial Catalog=apartman; Integrated Security=true");//bağlantı kodumuz
            baglanti.Open();//bağlantıyı açılır
            SqlConnection.ClearPool(baglanti);
            SqlConnection.ClearAllPools();
            return (baglanti);
        }
    }
}
