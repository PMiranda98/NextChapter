using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Input.Item
{
    public class UpdateItemDto
    {
        public required string Name { get; set; }
        public required string Author { get; set; }
        public required string LiteraryGenre { get; set; }
        public required int Year { get; set; }
        public required Photo Photo { get; set; }
    }
}
