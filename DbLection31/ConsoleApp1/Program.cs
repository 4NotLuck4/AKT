using DbLibrary.Database;
using DbLibrary.Repositories;
using DbLibrary.Services;

Console.WriteLine("Hello, World!");

string connectionString = "Data Source=mssql;Initial Catalog=ispp3102;Persist Security Info=True;User ID=ispp3102;Password=3102;Encrypt=True;Trust Server Certificate=True";
IDatabaseFactory factory = new MsSqlFactory(connectionString);



ReviewsRepository repository = new(factory);
ReviewsService service = new(repository);

var reviews = service.GetReviews();
var review = service.GetReview(3);

review = service.GetReviewsByGameId(1);

//IRepository<ReviewRepository> repository = new ReviewsRepository(factory);
//var repository = new ReviewsRepository(factory);

//var reviews = repository.GetAll();
//var review = repository.GetById(3);

//review.Comment = "qwe asd";
//repository.Update(review);

Console.WriteLine();

