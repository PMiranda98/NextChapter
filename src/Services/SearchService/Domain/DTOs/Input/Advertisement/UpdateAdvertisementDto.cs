using Domain.DTOs.Input.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Input.Advertisement
{
    public class UpdateAdvertisementDto
    {
        public required Guid Id { get; set; }
        public required DateTime UpdateAt { get; set; }
        public required int NumberOfOffers { get; set; }
        public required int SellingPrice { get; set; }
        public required string OfferTypePretended { get; set; }

        public required UpdateItemDto Item { get; set; }
    }
}
