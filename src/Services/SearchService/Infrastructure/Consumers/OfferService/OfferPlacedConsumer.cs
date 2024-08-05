using Application.Handlers.Offers;
using AutoMapper;
using Domain.DTOs.Input.Offer;
using EventBus.Contracts;
using MassTransit;
using MediatR;

namespace Infrastructure.Consumers.OfferService
{
    public class OfferPlacedConsumer : IConsumer<OfferPlaced>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OfferPlacedConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<OfferPlaced> context)
        {
            Console.WriteLine("=====> Consuming offer placed");

            var placedOfferDto = _mapper.Map<PlacedOfferDto>(context.Message);
            await _mediator.Send(new Placed.Command { PlacedOfferDto = placedOfferDto });
        }
    }
}
