using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Data.Common;

namespace DbLibrary.Database
{
    public interface IDatabaseFactory
    {
        IDbConnection CreateConnection();
    }

    public class MsSqlFactory(string connectionString) : IDatabaseFactory
    {
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);

        IDbConnection IDatabaseFactory.CreateConnection()
        {
            throw new NotImplementedException();
        }
    }
    public class SqliteFactory(string connectionString) : IDatabaseFactory
    {
        public IDbConnection CreateConnection() => new SqliteConnection(connectionString);

        IDbConnection IDatabaseFactory.CreateConnection()
        {
            throw new NotImplementedException();
        }
    }
}
