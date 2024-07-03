using AuctionService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IAuctionsRepository
    {
        public void CreateAuction(Auction auction, CancellationToken cancellationToken);
        //public Task UpdateAuction(CancellationToken cancellationToken);
        public void DeleteAuction(Guid Id, CancellationToken cancellationToken);
        public Task<List<Auction>> ListAuctions (CancellationToken cancellationToken);
        public Task<Auction> DetailsAuction(Guid Id, CancellationToken cancellationToken);
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
