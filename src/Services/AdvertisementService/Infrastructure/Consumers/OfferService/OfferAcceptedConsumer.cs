using Application.Handlers.Advertisements;
using Application.Handlers.Offer;
using AutoMapper;
using Domain.DTOs.Input.Offer;
using EventBus.Contracts;
using MassTransit;
using MediatR;

namespace Infrastructure.Consumers.OfferService
{
    public class OfferAcceptedConsumer : IConsumer<OfferAccepted>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OfferAcceptedConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<OfferAccepted> context)
        {
            Console.WriteLine("=====> Consuming offer accepted: " + context.Message.AdvertisementId);

            var offerAcceptedDto = _mapper.Map<OfferAcceptedDto>(context.Message);
            await _mediator.Send(new Accepted.Command { OfferAcceptedDto = offerAcceptedDto });
        }
    }
}
