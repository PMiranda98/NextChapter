using Application.Handlers.Advertisement;
using EventBus.Contracts;
using MassTransit;
using MediatR;

namespace Infrastructure.Consumers.AdvertisementService
{
    public class AdvertisementDeletedConsumer : IConsumer<AdvertisementDeleted>
    {
        private readonly IMediator _mediator;

        public AdvertisementDeletedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<AdvertisementDeleted> context)
        {
            Console.WriteLine("--> Consuming advertisement deleted: " + context.Message.Id);

            await _mediator.Send(new Delete.Command { Id = context.Message.Id });
        }
    }
}
