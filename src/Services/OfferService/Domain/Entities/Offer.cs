namespace Domain.Entities
{
    public class Offer
    {
        public Guid Id { get; set; }
        public required string AdvertisementId { get; set; }
        public required string Recipient { get; set; }
        public required string Sender { get; set; }
        public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public required DateTime UpdateAt { get; set; } = DateTime.UtcNow;
        public DateTime? EndedAt { get; set; }
        public required OfferStatus Status { get; set; } = OfferStatus.Live;
        public required OfferType Type { get; set; }
        public required int Amount { get; set; } = 0;
        public required string? Comment { get; set; }
        public List<Item>? ItemsToExchange { get; set; }
    }
}
