using EventBus.Contracts.Models;

namespace EventBus.Contracts
{
    public class AdvertisementUpdated
    {
        public required Guid Id { get; set; }
        public required DateTime UpdateAt { get; set; }
        public required int NumberOfOffers { get; set; }
        public required ItemUpdated Item { get; set; }
    }
}
