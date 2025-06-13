using ClassLibrary.Interfaces;
using ClassLibrary.Models;
using Dapper;
using System.Data;

namespace ClassLibrary.Repositories
{
    public class GamesRepository(IDbConnectionFactory factory)
    {
        private readonly IDbConnection _connection = factory.CreateConnection();

        public IEnumerable<Game> GetAll()
        {
            string sql = "SELECT * FROM Game";
            return _connection.Query<Game>(sql);
        }

        public Game? GetById(int id)
        {
            string sql = "SELECT * FROM Game WHERE Id = @Id";
            return _connection.QueryFirstOrDefault<Game>(sql, new {Id = id});
        }

        public void Create(Game game)
        {
            string sql = @"INSERT INTO Game (Title, Description, PublicationYear, Price) 
VALUES (@Title, @Description, @PublicationYear, @Price)";
            _connection.Execute(sql, game);
        }
        public void Update(Game game)
        {
            string sql = @"UPDATE Game SET Title = @Title, Description = @Description, PublicationYear = @PublicationYear 
WHERE Id = @Id";
            _connection.Execute(sql, game);
        }
        public void Delete(int id)
        {
            string sql = "DELETE FROM Game WHERE Id = @Id";
            _connection.Execute(sql, new {Id = id});
        }
    }
}