using Domain.DTOs.Output.Item;

namespace Domain.DTOs.Output.Advertisement;

public class AdvertisementDto
{
    public Guid Id { get; set; }
    public int SellingPrice { get; set; }
    public string? Seller { get; set; }
    public string? Buyer { get; set; }
    public int? SoldAmount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdateAt { get; set; }
    public DateTime EndedAt { get; set; }
    public string? Status { get; set; }
    public ItemDto? Item { get; set; }
}
