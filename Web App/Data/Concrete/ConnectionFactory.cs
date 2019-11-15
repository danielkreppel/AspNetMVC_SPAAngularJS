using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Data.Contract;

namespace Data.Concrete
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public IDbConnection GetConnection()
        {
            var conn = new SqlConnection(connectionString);
            conn.ConnectionString = connectionString;
            return conn;
        }
    }
}
