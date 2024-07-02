using API.Extensions;
using MongoDB.Driver;
using MongoDB.Entities;
using Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

await DB.InitAsync("SearchDb", MongoClientSettings.FromConnectionString(builder.Configuration.GetConnectionString("MongoDbConnection")));
try
{
    await DbInitializer.InitDb();
} catch (Exception e)
{
    Console.WriteLine(e);
}

app.Run();
