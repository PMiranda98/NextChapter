using AdvertisementService.Domain.Entities;
using Application.Interfaces;
using AutoMapper;
using EventBus.Contracts;
using MassTransit;

namespace Infrastructure.Publishers
{
    public class AdvertisementPublisher : IAdvertisementPublisher
    {
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public AdvertisementPublisher(IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
        }
        public async Task PublishAdvertisementCreated(Advertisement advertisement)
        {
            var advertisementCreated = _mapper.Map<AdvertisementCreated>(advertisement);
            await _publishEndpoint.Publish(advertisementCreated);
        }

        public async Task PublishAdvertisementUpdated(Advertisement advertisement)
        {
            var advertisementUpdated = _mapper.Map<AdvertisementUpdated>(advertisement);
            await _publishEndpoint.Publish(advertisementUpdated);
        }
        public async Task PublishAdvertisementDeleted(Guid id)
        {
            var advertisementDeleted = new AdvertisementDeleted { Id = id.ToString() };
            await _publishEndpoint.Publish(advertisementDeleted);
        }
    }
}
