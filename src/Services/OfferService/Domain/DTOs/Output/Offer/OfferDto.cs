using Domain.DTOs.Output.Item;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Output.Offer
{
    public class OfferDto
    {
        public Guid Id { get; set; }
        public required Guid AdvertisementId { get; set; }
        public required string Buyer { get; set; }
        public required DateTime Date { get; set; }
        public required OfferStatus Status { get; set; }
        public required OfferType Type { get; set; }
        public required int Amount { get; set; }
        public required string? Comment { get; set; }
        public List<ItemDto>? ItemsToExchange { get; set; }
    }
}
