using Microsoft.Data.Sqlite;

namespace SQLiteDataAccessLayer
{
    public static class DataAccessLayer
    {
        public static string DataBase { get; set; } = "test.db";
        public static string ConnectionString
        {
            get
            {
                SqliteConnectionStringBuilder builder = new()
                {
                    DataSource = DataBase
                };

                return builder.ConnectionString;
            }
        }

        public static object GetScalarValue(string query)
        {
            try
            {
                using (SqliteConnection connection = new(ConnectionString))
                {
                    connection.Open();

                    SqliteCommand command = new(query, connection);

                    return command.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }
}
