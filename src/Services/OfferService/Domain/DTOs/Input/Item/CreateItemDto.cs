using Domain.DTOs.Input.Photo;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Input.Item
{
    public class CreateItemDto
    {
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Author { get; set; }
        [Required]
        public required string LiteraryGenre { get; set; }
        [Required]
        public required int Year { get; set; }
        [Required]
        public required CreatePhotoDto Photo { get; set; }
    }
}
