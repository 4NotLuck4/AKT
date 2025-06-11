using Dapper;
using DbLibrary.Database;
using System.Data;

namespace DbLibrary.Repositories
{
    public interface IRepository<T> where T: class      //CRUD
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }

    public class ReviewsRepository(IDatabaseFactory factory) : IRepository<Review>
    {
        private readonly IDbConnection _db= factory.CreateConnection();
        public IEnumerable<Review> GetAll()
            => _db.Query<Review>("SELECT * FROM Review");

        public Review? GetById(int id)
            => _db.QueryFirstOrDefault<Review>("SELECT * FROM Review WHERE ID=@id", new { id });

        public void Create(Review entity) 
            => throw new NotImplementedException();

        public void Update(Review entity)
            => _db.Execute("UPDATE Review SET Comment=@Comment, [User]=@User " +
                "WHERE id=@id", entity);

        public void Delete(int id)
            => _db.Execute("DELETE Review WHERE Id=@id", new { id });
    }
}
