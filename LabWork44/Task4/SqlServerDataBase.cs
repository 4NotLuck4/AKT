using Microsoft.Data.SqlClient;

internal class SqlServerDataBase
{
    public static void CreateDataBase()
    {
        string queryCreateTabelRoles = @"CREATE TABLE Roles (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                Name NVARCHAR(20) NOT NULL
                );";

        string queryCreateTabelUsers = @"CREATE TABLE Users (
                Id INT IDENTITY(1,1) PRIMARY KEY,
                RoleId INT NOT NULL,
                Login NVARCHAR(20) NOT NULL,
                Password NVARCHAR(100) NOT NULL,
                FOREIGN KEY (RoleId) REFERENCES Roles(Id)
                );";

        SqlConnectionStringBuilder builder = new()
        {
            DataSource = "mssql",
            InitialCatalog = "ispp3102",
            UserID = "ispp3102",
            Password = "3102",
            TrustServerCertificate = true
        };

        using (SqlConnection connection = new(builder.ConnectionString))
        {
            connection.Open();
            SqlCommand command = new(queryCreateTabelRoles, connection);
            command.ExecuteNonQuery();

            command = new(queryCreateTabelUsers, connection);
            command.ExecuteNonQuery();
        }
    }
}
