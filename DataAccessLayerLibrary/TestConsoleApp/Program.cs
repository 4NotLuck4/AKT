using SQLite = SQLiteDataAccessLayer;
using MSSQL = MSSQLDataAccessLayer;
using System.Threading.Channels;

Console.WriteLine(SQLite.DataAccessLayer.ConnectionString);

Console.WriteLine(MSSQL.DataAccessLayer.ConnectionString);

Console.Write("Введите запрос для SQLite: ");
var query = Console.ReadLine();
Console.WriteLine(SQLite.DataAccessLayer.GetScalarValue(query));

Console.Write("Введите запрос для MSSQL: ");
query = Console.ReadLine();
Console.WriteLine(MSSQL.DataAccessLayer.GetScalarValue(query));