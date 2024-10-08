﻿using EventBus.Contracts.Models;
using System.ComponentModel.DataAnnotations;

namespace EventBus.Contracts
{
    public class AdvertisementUpdated
    {
        public required Guid Id { get; set; }
        public required DateTime UpdateAt { get; set; }
        public required int NumberOfOffers { get; set; }
        public required int SellingPrice { get; set; }
        public required string OfferTypePretended { get; set; }

        public required ItemUpdated Item { get; set; }
    }
}
