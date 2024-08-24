using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Input.Offer
{
    public class OfferAcceptedDto
    {
        [Required]
        public required string AdvertisementId { get; set; }
        [Required]
        public required string? Buyer { get; set; }
        [Required]
        public required string Seller { get; set; }
        [Required]
        public required DateTime EndedAt { get; set; }
        [Required]
        public required int Amount { get; set; }
    }
}
