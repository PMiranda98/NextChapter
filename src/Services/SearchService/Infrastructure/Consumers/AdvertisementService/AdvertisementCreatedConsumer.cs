using Application.Handlers.Advertisements;
using AutoMapper;
using Domain.Entities;
using EventBus.Contracts;
using MassTransit;
using MediatR;

namespace Infrastructure.Consumers.AdvertisementService
{
    public class AdvertisementCreatedConsumer : IConsumer<AdvertisementCreated>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AdvertisementCreatedConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<AdvertisementCreated> context)
        {
            Console.WriteLine("--> Consuming advertisement created: " + context.Message.Id);

            var advertisement = _mapper.Map<Advertisement>(context.Message);
            await _mediator.Send(new Create.Command { Advertisement = advertisement });
        }
    }
}
