using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Contracts
{
    public class AdvertisementFinished
    {
        public bool ItemSold { get; set; }
        public required string AdvertisementId { get; set; }
        public string? Buyer { get; set; }
        public required string Seller { get; set; }
        public int? Amount { get; set; }
    }
}
