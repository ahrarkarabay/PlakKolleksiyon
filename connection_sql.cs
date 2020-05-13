using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace b161200020_PlakKolleksiyon
{
    class connection_sql
    {
        //her formdan ulaşılacak sql server connection metodu oluşturuldu.
        public SqlConnection conn()
        {
            //Sql bağlantısı oluşturuldu.
            SqlConnection sql_conn = new SqlConnection(@"Data Source=DESKTOP-FLOAQUI\SQLEXPRESS;Initial Catalog=COLLECTION;Integrated Security=True");
            sql_conn.Open();
            return sql_conn;
        }

    }
}
