using Domain.DTOs.Output.Item;
using Domain.Entities;

namespace Domain.DTOs.Output.Offer
{
    public class CreatedOfferDto
    {
        public Guid Id { get; set; }
        public required OfferType Type { get; set; }
        public required int Amount { get; set; }
        public required string Comment { get; set; }
        public List<CreatedItemDto>? ItemsToExchange { get; set; }
    }
}
