using ClassLibrary.ConnectionFactory;
using ClassLibrary.Interfaces;
using ClassLibrary.Repositories;

string connectionString = "Data Source=mssql;Initial Catalog=ispp3102;Persist Security Info=True;User ID=ispp3102;Password=3102;Encrypt=True;Trust Server Certificate=True";
IDbConnectionFactory factory = new SqlConnectionFactory(connectionString);
GamesRepository repository = new(factory);

var games = repository.GetAll();
var game = repository.GetById(7);

game.Title = "rrrr";
repository.Update(game);

game.Title = "gfjkfghgf";
repository.Create(game);

try
{
    repository.Delete(10);
}
catch
{
    Console.WriteLine("Ошибка удаления");
}

Console.WriteLine();