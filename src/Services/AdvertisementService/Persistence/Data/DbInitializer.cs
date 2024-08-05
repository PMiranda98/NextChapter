using AdvertisementService.Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdvertisementService.Persistence.Data;

public class DbSeed
{
  public static async Task SeedData(DataContext context)
  {
    context.Database.Migrate();

    if (context.Advertisements.Any()) return;

    var advertisements = new List<Advertisement>()
      {
            new Advertisement()
            {
                Id = Guid.Parse("afbee524-5972-4075-8800-7d1f9d7b0a0c"),
                SellingPrice = 30,
                Seller = "bob",
                Buyer = null,
                SoldAmount = null,
                EndedAt = null,
                Status = AdvertisementStatus.Live,
                OfferTypePretended = OfferTypePretended.Purchase,
                Item = new Item
                {
                    Name = "And Then There Were None",
                    Author = "Agatha Christie",
                    LiteraryGenre = "Mystery",
                    Year = 1939,
                    Photo = new Photo{Id="1", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
                }
            },
            new Advertisement()
            {
                Id = Guid.Parse("c8c3ec17-01bf-49db-82aa-1ef80b833a9f"),
                SellingPrice = 40,
                Seller = "alice",
                Buyer = null,
                SoldAmount = null,
                EndedAt = null,
                Status = AdvertisementStatus.Live,
                OfferTypePretended = OfferTypePretended.Purchase,
                Item = new Item
                {
                    Name = "The Little Prince",
                    Author = "Antoine de Saint-Exupéry",
                    LiteraryGenre = "Fiction",
                    Year = 1943,
                    Photo = new Photo{Id="2", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
                }
            },
            new Advertisement()
            {
                Id = Guid.Parse("bbab4d5a-8565-48b1-9450-5ac2a5c4a654"),
                SellingPrice = 30,
                Seller = "bob",
                Buyer = null,
                SoldAmount = null,
                EndedAt = null,
                Status = AdvertisementStatus.Live,
                OfferTypePretended = OfferTypePretended.Both,
                Item = new Item
                {
                    Name = "Dream of the Red Chamber",
                    Author = "Cao Xueqin",
                    LiteraryGenre = "Novel",
                    Year = 1700,
                    Photo = new Photo{Id="3", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
                }
            },
            new Advertisement()
            {
                Id = Guid.Parse("155225c1-4448-4066-9886-6786536e05ea"),
                SellingPrice = 30,
                Seller = "tom",
                Buyer = null,
                SoldAmount = 25,
                EndedAt = DateTime.UtcNow.AddDays(-6),
                Status = AdvertisementStatus.Sold,
                OfferTypePretended = OfferTypePretended.Purchase,
                Item = new Item
                {
                    Name = "The Da Vinci Code",
                    Author = "Dan Brown",
                    LiteraryGenre = "Thriller",
                    Year = 2003,
                    Photo = new Photo{Id="4", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
                }
            },
            new Advertisement()
            {
                Id = Guid.Parse("466e4744-4dc5-4987-aae0-b621acfc5e39"),
                SellingPrice = 20,
                Seller = "alice",
                Buyer = null,
                SoldAmount = null,
                EndedAt = null,
                Status = AdvertisementStatus.Live,
                OfferTypePretended = OfferTypePretended.Purchase,
                Item = new Item
                {
                    Name = "The Lord of the Rings",
                    Author = "J.R.R Tolkien",
                    LiteraryGenre = "Fantasy",
                    Year = 1954, 
                    Photo = new Photo{Id="5", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }

                }
            },
            new Advertisement()
            {
                Id = Guid.Parse("dc1e4071-d19d-459b-b848-b5c3cd3d151f"),
                SellingPrice = 80,
                Seller = "bob",
                Buyer = null,
                SoldAmount = null,
                EndedAt = null,
                Status = AdvertisementStatus.Live,
                OfferTypePretended = OfferTypePretended.Exchange,
                Item = new Item
                {
                    Name = "Harry Potter and the Philosopher's Stone",
                    Author = "J.K. Rowling",
                    LiteraryGenre = "Fantasy",
                    Year = 1997,
                    Photo = new Photo{Id="6", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
                }
            },
            new Advertisement()
            {
                Id = Guid.Parse("47111973-d176-4feb-848d-0ea22641c31a"),
                SellingPrice = 80,
                Seller = "alice",
                Buyer = null,
                SoldAmount = null,
                EndedAt = null,
                Status = AdvertisementStatus.Live,
                OfferTypePretended = OfferTypePretended.Exchange,
                Item = new Item
                {
                    Name = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    LiteraryGenre = "Fantasy",
                    Year = 1937,
                    Photo = new Photo{Id="7", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
                }
            },
            new Advertisement()
            {
                Id = Guid.Parse("6a5011a1-fe1f-47df-9a32-b5346b289391"),
                SellingPrice = 10,
                Seller = "bob",
                Buyer = null,
                SoldAmount = null,
                EndedAt = null,
                Status = AdvertisementStatus.Live,
                OfferTypePretended = OfferTypePretended.Purchase,
                Item = new Item
                {
                    Name = "Don Quixote",
                    Author = "Miguel de Cervantes",
                    LiteraryGenre = "Novel",
                    Year = 1605,
                    Photo = new Photo{Id="8", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
                }
            },
            new Advertisement()
            {
                Id = Guid.Parse("40490065-dac7-46b6-acc4-df507e0d6570"),
                SellingPrice = 20,
                Seller = "tom",
                Buyer = null,
                SoldAmount = null,
                EndedAt = null,
                Status = AdvertisementStatus.Live,
                OfferTypePretended = OfferTypePretended.Purchase,
                Item = new Item
                {
                    Name = "A Tale of Two Cities",
                    Author = "Charles Dickens",
                    LiteraryGenre = "Historical Fiction",
                    Year = 1859,
                    Photo = new Photo{Id="9", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
                }
            },
            new Advertisement()
            {
                Id = Guid.Parse("3659ac24-29dd-407a-81f5-ecfe6f924b9b"),
                SellingPrice = 30,
                Seller = "bob",
                Buyer = null,
                SoldAmount = null,
                EndedAt = null,
                Status = AdvertisementStatus.Live,
                OfferTypePretended = OfferTypePretended.Both,
                Item = new Item
                {
                    Name = "The Lion, the Witch and the Wardrobe",
                    Author = "C.S. Lewis",
                    LiteraryGenre = "Fantasy",
                    Year = 1950,
                    Photo = new Photo{Id="10", Url = "https://cdn.pixabay.com/photo/2016/05/06/16/32/car-1376190_960_720.jpg" }
                }
            },
      };

    await context.Advertisements.AddRangeAsync(advertisements);
    await context.SaveChangesAsync();
  }
}
