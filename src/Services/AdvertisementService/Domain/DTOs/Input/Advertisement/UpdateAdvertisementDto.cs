using Domain.DTOs.Input.Item;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Input.Advertisement;

public class UpdateAdvertisementDto
{
    [Required]
    public int SellingPrice { get; set; }
    [Required]
    public required OfferTypePretended OfferTypePretended { get; set; }
    [Required]
    public required UpdateItemDto Item { get; set; }
}
