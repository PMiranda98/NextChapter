using Domain.Models;
using MongoDB.Driver;
using MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence.Data
{
    public class DbInitializer
    {
        public static async Task InitDb()
        {
            await DB.Index<Auction>()
                .Key(x => x.Item.Make, KeyType.Text)
                .Key(x => x.Item.Model, KeyType.Text)
                .Key(x => x.Item.Color, KeyType.Text)
                .CreateAsync();

            var count = await DB.CountAsync<Auction>();
            if (count == 0)
            {
                Console.WriteLine("No data - will attempt to seed");
                var itemData = await File.ReadAllTextAsync("Data/auctions.json");
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var items = JsonSerializer.Deserialize<List<Auction>>(itemData, options);
                if(items != null)
                    await DB.SaveAsync(items);
            }
        }
    }
}
