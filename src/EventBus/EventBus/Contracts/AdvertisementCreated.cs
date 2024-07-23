using EventBus.Contracts.Models;

namespace EventBus.Contracts
{
    public class AdvertisementCreated
    {
        public required Guid Id { get; set; }
        public required int SellingPrice { get; set; }
        public required string Seller { get; set; }
        public string? Buyer { get; set; }
        public int? SoldAmount { get; set; }
        public int NumberOfOffers { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public required string Status { get; set; }
        public required string OfferTypePretended { get; set; }
        public required ItemCreated Item { get; set; }
    }
}
