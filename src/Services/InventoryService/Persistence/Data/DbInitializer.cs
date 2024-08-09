using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace InventoryService.Persistence.Data;

public class DbSeed
{
  public static async Task SeedData(DataContext context)
  {
    context.Database.Migrate();

    if (context.Items.Any()) return;

    var items = new List<Item>()
      {    
        new Item()
        {
            Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
            Name = "BookTest1",
            Author = "AuthorTest1",
            LiteraryGenre = "LiteraryGenreTest1",
            Year = 2000,
            CreatedAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            Owner = "alice",
            Photo = new Photo{Id="1", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
        },
        new Item()
        {
            Id = Guid.Parse("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
            Name = "BookTest2",
            Author = "AuthorTest2",
            LiteraryGenre = "LiteraryGenreTest2",
            Year = 2000,
            CreatedAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            Owner = "alice",
            Photo = new Photo{Id="2", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
        },
        new Item()
        {
            Id = Guid.Parse("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"),
            Name = "BookTest3",
            Author = "AuthorTest3",
            LiteraryGenre = "LiteraryGenreTest3",
            Year = 2000,
            CreatedAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            Owner = "bob",
            Photo = new Photo{Id="3", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
        },
        new Item()
        {
            Id = Guid.Parse("155225c1-4448-4066-9886-6786536e05ea"),
            Name = "BookTest4",
            Author = "AuthorTest4",
            LiteraryGenre = "LiteraryGenreTest4",
            Year = 2000,
            CreatedAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            Owner = "alice",
            Photo = new Photo{Id="4", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
        },
        new Item()
        {
            Id = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"),
            Name = "BookTest5",
            Author = "AuthorTest5",
            LiteraryGenre = "LiteraryGenreTest5",
            Year = 2000,
            CreatedAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            Owner = "alice",
            Photo = new Photo{Id="5", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
        },
        new Item()
        {
            Id = Guid.Parse("dc1e4071-d19d-459b-b848-b5c3cd3d151f"),
            Name = "BookTest6",
            Author = "AuthorTest6",
            LiteraryGenre = "LiteraryGenreTest6",
            Year = 2000,
            CreatedAt = DateTime.UtcNow,
            UpdateAt = DateTime.UtcNow,
            Owner = "bob",
            Photo = new Photo{Id="6", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
        }
      };

    await context.Items.AddRangeAsync(items);
    await context.SaveChangesAsync();
  }
}
