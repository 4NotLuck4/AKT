using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;

Console.WriteLine("ADO.NET");
TestSqlite();

void TestMssql()
{
    Console.WriteLine("Microsoft SQL Server");

    string connectionString = "Data Source=mssql;Initial Catalog=ispp3102;Persist Security Info=True;User ID=ispp3102;Password=3102;Encrypt=True;Trust Server Certificate=True";

    SqlConnectionStringBuilder builder = new()
    {
        DataSource = "mssql",           // server
        InitialCatalog = "ispp3102",    // db
        UserID = "ispp3102",            // login
        Password = "3102",
        TrustServerCertificate=true
    };
   


    using SqliteConnection connection = new(connectionString);
}

void TestSqlite()
{
    Console.WriteLine("SQLite");

    var fileName = Path.Combine(Environment.CurrentDirectory, "db1.sqlite");

    SqliteConnectionStringBuilder builder = new ();
    builder.DataSource = fileName;
    string connectionString = builder.ConnectionString();

    connectionString = $"Data Surse={fileName}";

    using SqliteConnection connection = new(connectionString);
    connection.Open();

}