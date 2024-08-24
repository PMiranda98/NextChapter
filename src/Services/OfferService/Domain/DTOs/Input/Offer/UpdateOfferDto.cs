using Domain.DTOs.Input.Item;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Input.Offer
{
    public class UpdateOfferDto
    {
        [Required]
        public required string Recipient { get; set; }
        [Required]
        public required string Sender { get; set; }
        [Required]
        public required OfferStatus Status { get; set; }
        [Required]
        public required OfferType Type { get; set; }
        [Required]
        public required int Amount { get; set; }
        public string? Comment { get; set; }
        public List<UpdateItemDto>? ItemsToExchange { get; set; }
    }
}
