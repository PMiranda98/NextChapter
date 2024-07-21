using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Contracts
{
    public class AdvertisementDeleted
    {
        public required string Id { get; set; }
    }
}
