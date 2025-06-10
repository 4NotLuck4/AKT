using Dapper;
using DbLibrary.Database;
using System.Data;

namespace DbLibrary.Repositories
{
    public class ReviewRepository(IDatabaseFactory factory)
    {
        private readonly IDbConnection _db = factory.CreateConnection();

        public IEnumerable<Review> GetReviews()
            => _db.Query<Review>("SELECT * FROM Review");

        public Review? GetReviews(Review id) 
            => _db.QueryFirstOrDefault<Review>("SELECT * FROM Review WHERE ID=@id", new { id });
        public Review UpdateReviews(Review review) 
            => _db.Execute("UPDATE Review SET FROM Review WHERE ID=@id", review);
    }
}
