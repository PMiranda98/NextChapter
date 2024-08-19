using Domain.DTOs.Input.Item;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Input.Offer
{
    public class CreateOfferDto
    {
        [Required]
        public required string Recipient { get; set; }
        [Required]
        public required string Sender { get; set; }
        [Required]
        public required OfferType Type { get; set; }
        [Required]
        public required int Amount { get; set; }
        public string? Comment { get; set; }
        public List<CreateItemDto>? ItemsToExchange { get; set; }
    }
}
