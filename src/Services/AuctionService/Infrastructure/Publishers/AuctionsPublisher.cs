using Application.Interfaces;
using AuctionService.Domain.Entities;
using AutoMapper;
using EventBus.Contracts;
using MassTransit;

namespace Infrastructure.Publishers
{
    public class AuctionsPublisher : IAuctionsPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public AuctionsPublisher(IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }
        public async Task PublishAuctionCreated(Auction auction)
        {
            var auctionCreated = _mapper.Map<AuctionCreated>(auction);
            await _publishEndpoint.Publish(auctionCreated);
        }

        public async Task PublishAuctionUpdated(Auction auction)
        {
            var auctionUpdated = _mapper.Map<AuctionUpdated>(auction);
            await _publishEndpoint.Publish(auctionUpdated);
        }
        public async Task PublishAuctionDeleted(Guid id)
        {
            var auctionDeleted = new AuctionDeleted { Id = id.ToString() };
            await _publishEndpoint.Publish(auctionDeleted);
        }
    }
}
