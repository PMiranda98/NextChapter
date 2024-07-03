using AuctionService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuctionsPublisher
    {
        public Task PublishAuctionCreated(Auction auction);
        public Task PublishAuctionUpdated(Auction auction);
        public Task PublishAuctionDeleted(Guid id);
    }
}
