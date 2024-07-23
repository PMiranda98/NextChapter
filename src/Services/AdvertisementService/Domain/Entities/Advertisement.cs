namespace AdvertisementService.Domain.Entities;

public class Advertisement
{
    public Guid Id { get; set; }  
    public int SellingPrice { get; set; } = 0;
    public string? Seller { get; set; }  
    public string? Buyer { get; set; }
    public int? SoldAmount { get; set; }
    public int NumberOfOffers { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
    public DateTime? EndedAt { get; set; }
    public Status Status { get; set; } = Status.Live;
    public required Item Item { get; set; }
}
