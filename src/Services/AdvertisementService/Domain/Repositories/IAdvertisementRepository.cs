using AdvertisementService.Domain.Entities;

namespace Domain.Repositories
{
    public interface IAdvertisementRepository
    {
        public Task CreateAdvertisement(Advertisement advertisement, CancellationToken cancellationToken);
        //public Task UpdateAdvertisement(CancellationToken cancellationToken);
        public Task DeleteAdvertisement(Guid Id, CancellationToken cancellationToken);
        public Task<List<Advertisement>> ListAdvertisement (CancellationToken cancellationToken);
        public Task<Advertisement> DetailsAdvertisement(Guid Id, CancellationToken cancellationToken);
        public Task<Advertisement> DetailsAdvertisement(string Id, CancellationToken cancellationToken);
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
