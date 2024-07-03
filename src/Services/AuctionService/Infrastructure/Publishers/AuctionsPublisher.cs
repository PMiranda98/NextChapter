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
        public async void PublishAuctionCreated(Auction auction)
        {
            var auctionCreated = _mapper.Map<AuctionCreated>(auction);
            await _publishEndpoint.Publish(auctionCreated);
        }

        public async void PublishAuctionDeleted(Guid Id)
        {
            var auctionDeleted = _mapper.Map<AuctionDeleted>(Id);
            await _publishEndpoint.Publish(auctionDeleted);
        }

        public async void PublishAuctionUpdated(Auction auction)
        {
            var auctionUpdated = _mapper.Map<AuctionUpdated>(auction);
            await _publishEndpoint.Publish(auctionUpdated);
        }
    }
}
