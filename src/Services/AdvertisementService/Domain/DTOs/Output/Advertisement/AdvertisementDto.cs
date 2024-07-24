using Domain.DTOs.Output.Item;

namespace Domain.DTOs.Output.Advertisement;

public class AdvertisementDto
{
    public Guid Id { get; set; }
    public required int SellingPrice { get; set; }
    public required string? Seller { get; set; }
    public required string? Buyer { get; set; }
    public required int? SoldAmount { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdateAt { get; set; }
    public required DateTime EndedAt { get; set; }
    public required string? Status { get; set; }
    public required ItemDto? Item { get; set; }
}
