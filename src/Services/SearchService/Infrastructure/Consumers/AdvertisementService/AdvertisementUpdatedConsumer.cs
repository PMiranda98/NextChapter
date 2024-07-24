using Application.DTOs.Input.Advertisements;
using Application.Handlers.Advertisements;
using AutoMapper;
using EventBus.Contracts;
using MassTransit;
using MediatR;

namespace Infrastructure.Consumers.AdvertisementService
{
    public class AdvertisementUpdatedConsumer : IConsumer<AdvertisementUpdated>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AdvertisementUpdatedConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<AdvertisementUpdated> context)
        {
            Console.WriteLine("=====> Consuming advertisement updated: " + context.Message.Id);

            var updatedAdvertisementDto = _mapper.Map<UpdatedAdvertisementDto>(context.Message);
            await _mediator.Send(new Edit.Command { UpdatedAdvertisementDto = updatedAdvertisementDto });
        }
    }
}
