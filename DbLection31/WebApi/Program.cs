using DbLibrary.Database;
using DbLibrary.Repositories;

var builder = WebApplication.CreateBuilder(args);

//DB work
string connectionString = "Data Source=mssql;Initial Catalog=ispp3102;Persist Security Info=True;User ID=ispp3102;Password=3102;Encrypt=True;Trust Server Certificate=True";
builder.Services.AddSingleton<IDatabaseFactory>(new MsSqlFactory(connectionString));
builder.Services.AddScoped<ReviewsRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
