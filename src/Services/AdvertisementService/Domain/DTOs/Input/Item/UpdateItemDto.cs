using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Input.Item;

public class UpdateItemDto
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
    public required string Image { get; set; }
}
