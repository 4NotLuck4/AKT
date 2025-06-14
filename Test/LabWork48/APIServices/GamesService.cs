using System.Net.Http.Json;

namespace APIServices
{
    public class GamesService
    {
        private readonly HttpClient _httpClient;
        
        //2.1
        public GamesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //2.2
        public async Task<IEnumerable<Game>?> GetGamesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Game>>("games");
        }

        public async Task<Game?> GetGameByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Game>($"games/{id}");
        }

        public async Task<Game?> CreateGameAsync(Game game)
        {
            var response = await _httpClient.PostAsJsonAsync("games", game);
            return await response.Content.ReadFromJsonAsync<Game>();
        }

        public async Task UpdateGameAsync(int id, Game game)
        {
            await _httpClient.PutAsJsonAsync($"games/{id}", game);
        }
        public async Task DeleteGameAsync(int id, Game game)
        {
            await _httpClient.DeleteAsync($"games/{id}");
        }
    }
}
