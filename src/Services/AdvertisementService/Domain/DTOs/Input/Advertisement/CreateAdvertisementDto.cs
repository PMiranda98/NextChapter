using System.ComponentModel.DataAnnotations;
using Domain.DTOs.Input.Item;

namespace Domain.DTOs.Input.Advertisement;

public class CreateAdvertisementDto
{
    public Guid Id { get; set; }
    [Required]
    public int SellingPrice { get; set; }
    [Required]
    public required CreateItemDto Item { get; set; }
}
