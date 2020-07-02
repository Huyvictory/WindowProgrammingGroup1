using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace AnotherTest
{
    class ConnectDB
    {
        public ConnectDB()
        {
            SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=DBReadingProgram;Integrated Security=True");
        }
        public SqlConnection getcon()
        {
            return new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=DBReadingProgram;Integrated Security=True");
        }
    }
}
