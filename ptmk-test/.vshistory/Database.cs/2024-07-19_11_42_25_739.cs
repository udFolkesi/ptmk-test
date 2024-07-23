using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ptmk_test
{
    internal class Database
    {
        private string ConnectionString = "";

        public void CreateTable()
        {
            using(SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
            }
        }
    }
}
