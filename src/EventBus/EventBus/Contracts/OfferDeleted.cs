using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Contracts
{
    public class OfferDeleted
    {
        public required string Id { get; set; }
        public required string AdvertisementId { get; set; }
    }
}
