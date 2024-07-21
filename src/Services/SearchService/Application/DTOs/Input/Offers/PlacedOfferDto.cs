using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Input.Offers
{
    public class PlacedOfferDto
    {
        public required string Id { get; set; }
        public required string AdvertisementId { get; set; }
        public required string Buyer { get; set; }
        public required DateTime Date { get; set; }
        public required int Amount { get; set; }
    }
}
