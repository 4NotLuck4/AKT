//using ClassLibrary.Models;

//namespace ClassLibrary.Services
//{
//    public class GamesService
//    {
//        public IEnumerable<Game> GetAll()
//        {
//            logger.LogInformation("Getting all games");
//            return repository.GetAll();
//        }

//        public Game? GetById(int id)
//        {
//            logger.LogInformation($"Getting game by ID: {id}");
//            return repository.GetById(id);
//        }

//        public void Create(Game game)
//        {
//            if (string.IsNullOrEmpty(game.Title))
//                throw new ArgumentException("Game name is required");

//            if (game.PublicationYear > DateTime.Now)
//                throw new ArgumentException("Release date cannot be in the future");

//            logger.LogInformation($"Creating new game: {game.Title}");
//            repository.Create(game);
//        }

//        public void Update(Game game)
//        {
//            if (game.Id <= 0)
//                throw new ArgumentException("Invalid game ID");

//            logger.LogInformation($"Updating game ID: {game.Id}");
//            repository.Update(game);
//        }

//        public void Delete(int id)
//        {
//            if (id <= 0)
//                throw new ArgumentException("Invalid game ID");

//            logger.LogInformation($"Deleting game ID: {id}");
//            repository.Delete(id);
//        }
//    }
//}
