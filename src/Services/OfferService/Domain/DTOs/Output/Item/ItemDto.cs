using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.Output.Photo;
using Domain.Entities;

namespace Domain.DTOs.Output.Item
{
    public class ItemDto
    {
        public required string Name { get; set; }
        public required string Author { get; set; }
        public required string LiteraryGenre { get; set; }
        public required int Year { get; set; }
        public required PhotoDto Photo { get; set; }
    }
}
