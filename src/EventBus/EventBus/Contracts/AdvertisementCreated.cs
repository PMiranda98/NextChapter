using EventBus.Contracts.Models;

namespace EventBus.Contracts
{
    public class AdvertisementCreated
    {
        public Guid Id { get; set; }
        public required int SellingPrice { get; set; }
        public string? Seller { get; set; }
        public string? Buyer { get; set; }
        public int? SoldAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public required string Status { get; set; }
        public required ItemCreated Item { get; set; }
    }
}
