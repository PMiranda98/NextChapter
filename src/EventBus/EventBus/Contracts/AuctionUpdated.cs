using EventBus.Contracts.Models;

namespace EventBus.Contracts
{
    public class AuctionUpdated
    {
        public Guid Id { get; set; }
        public ItemUpdated? Item { get; set; }
    }
}
