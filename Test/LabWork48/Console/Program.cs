using System;

class Program
{
    static async Task Main(string[] args)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:5001/") // Базовый адрес API
        };

        var gamesService = new GamesService(httpClient);

        try
        {
            // Получение всех игр
            Console.WriteLine("All games:");
            var games = await gamesService.GetAllGamesAsync();
            foreach (var game in games)
            {
                Console.WriteLine($"{game.Id}: {game.Name} - {game.Price:C}");
            }

            // Создание новой игры
            Console.WriteLine("\nCreating new game...");
            var newGame = new Game { Name = "New Game", Price = 49.99m, Description = "New game description" };
            var createdGame = await gamesService.CreateGameAsync(newGame);
            Console.WriteLine($"Created game with ID: {createdGame.Id}");

            // Обновление игры
            Console.WriteLine("\nUpdating game...");
            createdGame.Price = 59.99m;
            await gamesService.UpdateGameAsync(createdGame.Id, createdGame);
            Console.WriteLine("Game updated");

            // Удаление игры
            Console.WriteLine("\nDeleting game...");
            await gamesService.DeleteGameAsync(createdGame.Id);
            Console.WriteLine("Game deleted");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}