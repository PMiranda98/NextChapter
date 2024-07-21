using EventBus.Contracts.Models;

namespace EventBus.Contracts
{
    public class AdvertisementUpdated
    {
        public Guid Id { get; set; }
        public required ItemUpdated Item { get; set; }
    }
}
