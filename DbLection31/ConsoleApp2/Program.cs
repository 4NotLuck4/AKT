using WebApiServices;

Console.WriteLine("console app 2");

var client = new HttpClient()
{
    BaseAddress = new Uri("httml://localhost:5150/api/")
};

ReviewsApiService service = (client);
try
{
    var reviews = await service.GetReviewsAsync();
    var review = await service.GetReviewAsync(5);
    review.Comment = "asd";
    await service.UpdateReviewAsync(review);
    await service.DeleteReviewAsync(2);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();