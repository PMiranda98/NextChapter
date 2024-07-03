using EventBus.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Contracts
{
    public class AuctionUpdated
    {
        public Guid Id { get; set; }
        public ItemUpdated? Item { get; set; }
    }
}
