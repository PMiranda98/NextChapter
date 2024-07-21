using AdvertisementService.Domain.Entities;
using AdvertisementService.Persistence.Data;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly DataContext _dataContext;

        public AdvertisementRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Advertisement>> ListAdvertisement(CancellationToken cancellationToken)
        {
            // Eager Loading when using .Include() and mention the navigation property Item. (it will bring all the needed data in one call).
            // This prevents the need of doing multiple calls to the database instance.
            return await _dataContext.Advertisements.Include(x => x.Item).OrderBy(x => x.Item.Name).ToListAsync(cancellationToken);
        }

        public async Task<Advertisement> DetailsAdvertisement(Guid Id, CancellationToken cancellationToken)
        {
            // Lazy Loading - If we only have this line this is consider Lazy Loading, the advertisement wont have the Item property filled.
            // This is used when we are confident that we don't need to use the related entites instantly.
            /*
                // var advertisement = await _dataContext.Advertisements.FindAsync(request.Id, cancellationToken);
             */

            // Explicit loading - Works like lazy loading, but after the first call, more calls are made depending on the navigation properties that we want to fill.
            // Provides access to change tracking information and loading information for all reference (i.e non-collection) navigation properties of this entity.
            /*
                // if (advertisement != null)
                // await _dataContext.Entry(advertisement).Reference(x => x.Item).LoadAsync(cancellationToken);
             */

            // Provides access to change tracking information and loading information for all collection navigation properties of this entity
            /*
                //if (advertisement != null)
                // _dataContext.Entry(advertisement).Collections(x => x.Items).LoadAsync(cancelationToken);
             */
            // Eager Loading
            return await _dataContext.Advertisements.Include(x => x.Item).Where(x => x.Id == Id).FirstAsync();
        }


        public void CreateAdvertisement(Advertisement advertisement, CancellationToken cancellationToken)
        {
            _dataContext.Advertisements.Add(advertisement);
        }

        /*
        public async Task UpdateAdvertisement(CancellationToken cancellationToken)
        {

        }
        */

        public async void DeleteAdvertisement(Guid Id, CancellationToken cancellationToken)
        {
            // Does not need to do a Eager loading because the foreign key constraint is of type ON DELETE CASCADE.
            var advertisement = await _dataContext.Advertisements.FindAsync(Id);
            if (advertisement != null)
                _dataContext.Advertisements.Remove(advertisement);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Advertisement> DetailsAdvertisement(string Id, CancellationToken cancellationToken)
        {
            return await _dataContext.Advertisements.Include(x => x.Item).Where(x => x.Id.ToString() == Id).FirstAsync();
        }
    }
}
