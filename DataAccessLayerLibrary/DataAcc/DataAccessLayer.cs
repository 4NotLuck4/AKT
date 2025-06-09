using Microsoft.Data.SqlClient;

namespace MSSQLDataAccessLayer
{
    public static class DataAccessLayer
    {
        public static string ServerName { get; set; } = "mssql";
        public static string DataBase { get; set; } = "ispp3102";
        public static string Login { get; set; } = "ispp3102";
        public static string Password { get; set; } = "3102";
        public static string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new()
                {
                    InitialCatalog = ServerName,
                    DataSource = DataBase,
                    UserID = Login,
                    Password = Password,
                    TrustServerCertificate = true
                };
                
                return builder.ConnectionString;
            }
        }

        public static object GetScalarValue(string query)
        {
            try
            {
                using (SqlConnection connection = new(ConnectionString))
                {
                    connection.Open();

                    SqlCommand command = new(query, connection);

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
