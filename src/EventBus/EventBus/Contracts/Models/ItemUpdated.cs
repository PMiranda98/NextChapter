using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Contracts.Models
{
    public class ItemUpdated
    {
        public required string Name { get; set; }
        public required string Author { get; set; }
        public required string LiteraryGenre { get; set; }
        public required int Year { get; set; }
        public required Photo Photo { get; set; }
    }
}
