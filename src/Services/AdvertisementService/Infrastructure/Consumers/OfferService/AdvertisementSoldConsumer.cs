using Application.Handlers.Advertisements;
using AutoMapper;
using Domain.DTOs.Input.Advertisement;
using EventBus.Contracts;
using MassTransit;
using MediatR;

namespace Infrastructure.Consumers.OfferService
{
    public class AdvertisementSoldConsumer : IConsumer<AdvertisementSold>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AdvertisementSoldConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<AdvertisementSold> context)
        {
            Console.WriteLine("=====> Consuming advertisement finished: " + context.Message.AdvertisementId);

            var finishedAdvertisementDto = _mapper.Map<SoldAdvertisementDto>(context.Message);
            await _mediator.Send(new Sold.Command { SoldAdvertisementDto = finishedAdvertisementDto });
        }
    }
}
