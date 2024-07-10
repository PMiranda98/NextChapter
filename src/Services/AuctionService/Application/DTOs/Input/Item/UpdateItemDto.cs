using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Input.Item;

public class UpdateItemDto
{
    [Required]
    public required string Make { get; set; }
    [Required]
    public required string Model { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public required string Color { get; set; }
    [Required]
    public int Mileage { get; set; }
}
