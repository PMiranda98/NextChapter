using AdvertisementService.Domain.Entities;

namespace Application.Interfaces
{
    public interface IAdvertisementPublisher
    {
        public Task PublishAdvertisementCreated(Advertisement advertisement);
        public Task PublishAdvertisementUpdated(Advertisement advertisement);
        public Task PublishAdvertisementDeleted(Guid id);
    }
}
