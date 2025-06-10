using Microsoft.Data.SqlClient;
using System.Data;

namespace DbLibrary.Database
{
    public interface IDatabaseFactory
    {
        IDbConnection CreateConnection();
    }

    public class MsSqlFactory(string connectionString) : IDatabaseFactory
    {
        public IDbConnetion CreateConnection() => new SqlConnetion(connectionString);
    }
    public class SqliteFactory(string connectionString) : IDatabaseFactory
    {
        public IDbConnetion CreateConnection() => new SqliteConnetion(connectionString);
    }
}
