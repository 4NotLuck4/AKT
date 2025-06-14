using ClassLibrary.Interfaces;
using Microsoft.Data.Sqlite;
using System.Data;

namespace ClassLibrary.ConnectionFactory
{
    public class SqliteConnectionFactory(string connectionString) : IDbConnectionFactory
    {
        public IDbConnection CreateConnection() => new SqliteConnection(connectionString);
    }
}
