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
        public required DateTime Date { get; set; }
        public required OfferStatus Status { get; set; }
        public required OfferType Type { get; set; }
        public int Amount { get; set; } = 0;
        public string? Comment { get; set; }
        public List<Item>? ItemsToExchange { get; set; }
    }
}
