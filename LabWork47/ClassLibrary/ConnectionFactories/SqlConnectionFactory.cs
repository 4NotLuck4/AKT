using ClassLibrary.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ClassLibrary.ConnectionFactory
{
    public class SqlConnectionFactory(string connectionString) : IDbConnectionFactory
    {
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);
    }
}
