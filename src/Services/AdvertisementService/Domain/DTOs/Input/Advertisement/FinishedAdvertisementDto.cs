using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.Input.Advertisement
{
    public class FinishedAdvertisementDto
    {
        [Required]
        public required bool ItemSold { get; set; }
        [Required]
        public required string AdvertisementId { get; set; }
        [Required]
        public required string? Buyer { get; set; }
        [Required]
        public required string Seller { get; set; }
        [Required]
        public required int? Amount { get; set; }
    }
}
