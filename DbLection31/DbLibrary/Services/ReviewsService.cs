using DbLibrary.Repositories;
using DbLibrary.Models;

namespace DbLibrary.Services
{
    public class ReviewsService(ReviewsRepository repository)
    {
        private readonly ReviewsRepository _repository = repository;

        public IEnumerable<Review> GetReviews()
        {
            Console.WriteLine("start getting...");
            var reviews = _repository.GetAll();
            Console.WriteLine("stop getting...");
            return reviews;
        }

        public Review GetReview(int id)
        {
            var review = _repository.GetById(id);
            if (review is null)
                throw new KeyNotFoundException();
            return review;
        }

        public IEnumerable<Review> GetReviewsByGameId(int id)
        {
            var review = _repository.GetAll()
                .Where(r. => r.Game == id)

        }
    }
}
