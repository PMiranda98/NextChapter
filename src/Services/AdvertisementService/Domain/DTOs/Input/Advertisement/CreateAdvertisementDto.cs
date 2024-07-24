using System.ComponentModel.DataAnnotations;
using Domain.DTOs.Input.Item;
using Domain.Entities;

namespace Domain.DTOs.Input.Advertisement;

public class CreateAdvertisementDto
{
    [Required]
    public required int SellingPrice { get; set; }
    [Required]
    public required OfferTypePretended OfferTypePretended { get; set; }
    [Required]
    public required CreateItemDto Item { get; set; }
}
