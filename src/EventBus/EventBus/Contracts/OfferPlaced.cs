using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Contracts
{
    public class OfferPlaced
    {
        public required string Id { get; set; }
        public required string AdvertisementId { get; set; }
        public required string Buyer { get; set; }
        public required DateTime Date { get; set; }
        public required string Status { get; set; }
        public required string Type{ get; set; }
        public required int Amount { get; set; }
    }
}
