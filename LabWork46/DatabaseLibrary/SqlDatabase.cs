using Microsoft.Data.SqlClient;
using System.Data.Common;
namespace DatabaseLibrary
{
    public class SqlDatabase : IDatabase
    {
        private readonly string _connectionString;

        public SqlDatabase(string server, string database, string userName, string password)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = server,
                InitialCatalog = database,
                UserID = userName,
                Password = password//,
                //Encrypt=false
            };
            _connectionString = builder.ToString();
        }

        public int ExecutrQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public void InsertGame(string name, decimal price, int releaseYear)
        {
            throw new NotImplementedException();
        }

        public bool UpdateGame(int id, string newName, decimal newPrice)
        {
            throw new NotImplementedException();
        }
    }
}
