using DbLibrary;
using DbLibrary.Database;
using DbLibrary.Repositories;
using Lection0605;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using System.Data;


string connectionString = "Data Source=mssql;Initial Catalog=ispp3102;Persist Security Info=True;User ID=ispp3102;Password=3102;Encrypt=True;Trust Server Certificate=True";
IDatabaseFactory factory = new MsSqlFactory(connectionString);
ReviewRepository repository = new(factory);

var reviews = repository.GetReviews();
var review = repository.GetReviews(3);
review.Comment = "ewfaff 11 wedw";
repository.UpdateReviews(review);



Console.WriteLine("ADO.NET");

//var reviews = DatabaseContext.GetReviews();
//var review = DatabaseContext.GetReviews(3);




// string
//DatadaseContext.ExecuteCommand(query);
//TestMssql();

void TestMssql()
{
    Console.WriteLine("Microsoft SQL Server");


    SqlConnectionStringBuilder builder = new()
    {
        DataSource = "mssql",           // server
        InitialCatalog = "ispp3102",    // db
        UserID = "ispp3102",            // login
        Password = "3102",
        TrustServerCertificate = true
    };
    connectionString = builder.ConnectionString;

    using SqlConnection connection = new(connectionString);
    connection.Open();

    string query = "UPDATE Game SET Price+=1";
    SqlCommand command = new(query, connection);

    //command.ExecuteNonQuery();                      // DDL/DML
    //int rowsCount = command.ExecuteNonQuery();      // DML

    //query = "SELECT Title FROM Game WHERE Id=3";
    //command = new(query, connection);
    //object result = command.ExecuteScalar();
    //decimal price = Convert.ToDecimal(command.ExecuteScalar());
    //string title = command.ExecuteScalar().ToString();

    query = "SELECT * FROM Game";
    command = new(query, connection);
    var reader = command.ExecuteReader();

    DataTable schema = reader.GetSchemaTable();
    Console.WriteLine();
    //SqlDataAdapter adapter = new(query, connection);
    //DataTable table = new();
    //adapter.Fill(table);        //Заполнение DataTable

    //// ... изменили таблицу
    //SqlCommandBuilder commandBuilder = new(adapter);
    //adapter.Update(table);
    //table.Clear();
    //adapter.Fill(table);
    
    //command = new(query, connection);
    //var reader = command.ExecuteReader();

    ///*DataTable table = new("games");*/
    //table.Load(reader);

    //var columnsCount = reader.FieldCount;

    List<Game> games = new();
    while (reader.Read())       //построчное чтение строки   
    {
        Game game = new()
        {
            Id = Convert.ToInt32(reader["ID"]),
            Title = reader["Title"].ToString(),
            Price = Convert.ToDecimal(reader["Price"])
        };
        games.Add(game);
        
        /*var id = reader.GetInt32(0);
        var title = reader.GetString(1);
        var price = reader.GetDecimal(5);
        Console.WriteLine($"{id} {title} {price}");
        Console.WriteLine();*/

        /*object[] cells = new object[reader.FieldCount];
        reader.GetValues(cells);
        string row = String.Join(",", cells);
        Console.WriteLine(row);*/

        //for (int i = 0; i < columnsCount; i++)
        //    Console.Write($"{reader[i]}; ");
        //Console.WriteLine();

        //Console.WriteLine($"{reader[0]}, {reader[1]}");
        //if (reader["Description"] != DBNull.Value)
        //    Console.WriteLine($"Descriction {reader["Description"]}");
        //else
        //    Console.WriteLine($"Descriction: empry");
        //Console.WriteLine();

        //// reader[0]
        ////reader["Title"]
    }

    // долгий вариант
    //if (reader.HasRows)     //есть строки
    //{
    //    while (reader.Read())       //построчное чтение строки   
    //    {
    //        Console.WriteLine($"{reader[0]}, {reader[1]}");
    //    }
    //}
    //else
    //{
    //    Console.WriteLine("empty result");
    //}
}

void TestSqlite()
{
    Console.WriteLine("SQLite");

    var fileName = Path.Combine(Environment.CurrentDirectory, "db1.sqlite");
    #region  connection
    SqlConnectionStringBuilder builder = new ();
    builder.DataSource = fileName;
    string connectionString = builder.ConnectionString;

    connectionString = $"Data Source={fileName}";
    #endregion
    using SqliteConnection connection = new(connectionString);
    connection.Open();

    //string query = "UPDATE Game SET Price+=1";
    //SqlCommand command = new(query, connection);

    ////command.ExecuteNonQuery();                      // DDL/DML
    ////int rowsCount = command.ExecuteNonQuery();      // DML

    //query = "SELECT ... FROM ...";
    //command = new(query, connection);
    //object result = command.ExecuteScalar();
    //decimal price = Convert.ToDecimal(command.ExecuteScalar());
    //string title = command.ExecuteScalar().ToString();
}