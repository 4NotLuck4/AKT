using ClassLibrary.DataBase;
using ClassLibrary.Interfaces;
using Dapper;
using System.Data;

namespace APIServices
{
    public class GamesService(IDbConnectionFactory factory)
    {
        private readonly IDbConnection _connection = factory.CreateConnection();

        public IEnumerable<Game> GetAll()
            => _connection.Query<Game>("SELECT * FROM Game");

        public Game GetGame(int id)
    }
}
