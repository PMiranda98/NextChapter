using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Offer
    {
        public Guid Id { get; set; }
        public required string AdvertisementId { get; set; }
        public required string Buyer { get; set; }
        public required DateTime Date { get; set; } = DateTime.UtcNow;
        public required OfferStatus Status { get; set; } = OfferStatus.Live;
        public required OfferType Type { get; set; }
        public required int Amount { get; set; } = 0;
        public required string? Comment { get; set; }
        public List<Item>? ItemsToExchange { get; set; }
    }
}
