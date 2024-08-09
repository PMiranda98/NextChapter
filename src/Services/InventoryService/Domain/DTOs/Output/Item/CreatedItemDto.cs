using Domain.Entities;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Output.Item
{
    public class CreatedItemDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Author { get; set; }
        public required string LiteraryGenre { get; set; }
        public required int Year { get; set; }
        public required string Owner { get; set; }
        public required Photo Photo { get; set; }
    }
}
