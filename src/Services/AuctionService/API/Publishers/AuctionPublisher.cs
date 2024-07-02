using AuctionService.Domain.Entities;
using AutoMapper;
using Domain.Interfaces;
using EventBus.Contracts;
using MassTransit;

namespace API.Publishers
{
    public class AuctionPublisher : IAuctionPublisher
    {
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public AuctionPublisher(IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }
        public async Task AuctionCreatedPublisher(Auction auction)
        {
            var auctionCreated = _mapper.Map<AuctionCreated>(auction);
            await _publishEndpoint.Publish(auctionCreated);
        }
    }
}
