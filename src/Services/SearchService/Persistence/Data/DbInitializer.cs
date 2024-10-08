﻿using Domain.Entities;
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
            // Create indexes for these fields that we want to be able to search on.
            await DB.Index<Advertisement>()
                .Key(x => x.Item.LiteraryGenre, KeyType.Text)
                .Key(x => x.Item.Name, KeyType.Text)
                .Key(x => x.Item.Author, KeyType.Text)
                .CreateAsync();

            var count = await DB.CountAsync<Advertisement>();
            if (count == 0)
            {
                Console.WriteLine("No data - will attempt to seed!");
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "advertisements.json");
                Console.WriteLine($"{path}");
                var itemData = await File.ReadAllTextAsync(path);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var items = JsonSerializer.Deserialize<List<Advertisement>>(itemData, options);
                if(items != null)
                    await DB.SaveAsync(items);
            }
        }
    }
}
