using Microsoft.Data.Sqlite;
using System.IO;
namespace DatabaseLibrary
{
    public class SqliteDatabase : IDatabase
    {
        private readonly string _connectionString;

        public SqliteDatabase(string filePath, string fileName)
        {
            var builder = new SqliteConnectionStringBuilder
            {
                DataSource = Path.Combine(filePath, fileName)
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
