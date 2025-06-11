using DbLibrary;
using System.Net.Http.Json;

namespace WebApiServices
{
    public class ReviewsApiService(HttpClient client)
    {
        private readonly HttpClient _client = client;

        public async Task<IEnumerable<Review>?> GetReviewsAsync()
            => await _client.GetFromJsonAsync<IEnumerable<Review>>("reviws");

        public async Task<Review?> GetReviewAsync(int id)
            => await _client.GetFromJsonAsync<Review>($"reviws/{id}");

        public async Task UpdateReviewAsync(Review review)
        {
            var responce = await _client.PutAsJsonAsync($"reviws/{review.Id}", review);
            responce.EnsureSuccessStatusCode();     //Генирирует исключение если...
        }

        public async Task DeleteReviewAsync(int id)
        {
            var responce = await _client.DeleteAsync($"reviws/{id}");
            responce.EnsureSuccessStatusCode();
        }
    }
}
