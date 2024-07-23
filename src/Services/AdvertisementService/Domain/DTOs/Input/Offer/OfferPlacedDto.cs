using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Input.Offer
{
    public class OfferPlacedDto
    {
        public required string Id { get; set; }
        public required string AdvertisementId { get; set; }
        public required DateTime Date { get; set; }
    }
}
