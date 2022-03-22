using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace adoproject.Models
{
    public class DBconnection
    {
       public SqlConnection connection;
        public DBconnection()
        {
            connection = new SqlConnection(Dbconfig.ConnectionStr);
        }
    }
}
