using Domain.DTOs.Input.Item;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Input.Advertisement;

public class UpdateAdvertisementDto
{
    [Required]
    public required UpdateItemDto Item { get; set; }
}
