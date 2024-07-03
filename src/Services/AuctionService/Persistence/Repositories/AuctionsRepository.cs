using AuctionService.Domain.Entities;
using AuctionService.Persistence.Data;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class AuctionsRepository : IAuctionsRepository
    {
        private readonly DataContext _dataContext;

        public AuctionsRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Auction>> ListAuctions(CancellationToken cancellationToken)
        {
            // Eager Loading when using .Include() and mention the navigation property Item. (it will bring all the needed data in one call).
            // This prevents the need of doing multiple calls to the database instance.
            return await _dataContext.Auctions.Include(x => x.Item).OrderBy(x => x.Item.Make).ToListAsync(cancellationToken);
        }

        public async Task<Auction> DetailsAuction(Guid Id, CancellationToken cancellationToken)
        {
            // Lazy Loading - If we only have this line this is consider Lazy Loading, the auction wont have the Item property filled.
            // This is used when we are confident that we don't need to use the related entites instantly.
            /*
                // var auction = await _dataContext.Auctions.FindAsync(request.Id, cancellationToken);
             */

            // Explicit loading - Works like lazy loading, but after the first call, more calls are made depending on the navigation properties that we want to fill.
            // Provides access to change tracking information and loading information for all reference (i.e non-collection) navigation properties of this entity.
            /*
                // if (auction != null)
                // await _dataContext.Entry(auction).Reference(x => x.Item).LoadAsync(cancellationToken);
             */

            // Provides access to change tracking information and loading information for all collection navigation properties of this entity
            /*
                //if (auction != null)
                // _dataContext.Entry(auction).Collections(x => x.Items).LoadAsync(cancelationToken);
             */
            // Eager Loading
            return await _dataContext.Auctions.Include(x => x.Item).Where(x => x.Id == Id).FirstAsync();
        }


        public void CreateAuction(Auction auction, CancellationToken cancellationToken)
        {
            _dataContext.Auctions.Add(auction);
        }

        /*
        public async Task UpdateAuction(CancellationToken cancellationToken)
        {

        }
        */

        public async void DeleteAuction(Guid Id, CancellationToken cancellationToken)
        {
            // Does not need to do a Eager loading because the foreign key constraint is of type ON DELETE CASCADE.
            var auction = await _dataContext.Auctions.FindAsync(Id);
            if (auction != null)
                _dataContext.Auctions.Remove(auction);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
