using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Repository.Contract;

namespace Repository.Concrete
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["DTAppCon"].ConnectionString;
        public IDbConnection GetConnection()
        {
                var conn = new SqlConnection(connectionString);
                conn.ConnectionString = connectionString;
                return conn;
        }
    }
}
