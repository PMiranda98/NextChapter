using Domain.DTOs.Output.Item;
using Domain.Entities;

namespace Domain.DTOs.Output.Advertisement;

public class AdvertisementDto
{
    public Guid Id { get; set; }
    public required int SellingPrice { get; set; }
    public required string? Seller { get; set; }
    public required string? Buyer { get; set; }
    public required int? SoldAmount { get; set; }
    public int NumberOfOffers { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdateAt { get; set; }
    public required DateTime EndedAt { get; set; }
    public required string? Status { get; set; }
    public required OfferTypePretended OfferTypePretended { get; set; }
    public required ItemDto? Item { get; set; }
}
