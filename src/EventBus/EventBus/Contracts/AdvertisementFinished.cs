using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Contracts
{
    public class AdvertisementFinished
    {
        public required bool ItemSold { get; set; }
        public required string AdvertisementId { get; set; }
        public required string? Buyer { get; set; }
        public required string Seller { get; set; }
        public required DateTime? EndedAt { get; set; }
        public required int? Amount { get; set; }
    }
}
