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
        public void PublishAuctionCreated(Auction auction);
        public void PublishAuctionUpdated(Auction auction);
        public void PublishAuctionDeleted(Guid Id);
    }
}
