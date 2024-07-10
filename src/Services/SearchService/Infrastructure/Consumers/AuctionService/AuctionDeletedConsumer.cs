using Application.Handlers.Auctions;
using EventBus.Contracts;
using MassTransit;
using MediatR;

namespace Infrastructure.Consumers.AuctionService
{
    public class AuctionDeletedConsumer : IConsumer<AuctionDeleted>
    {
        private readonly IMediator _mediator;

        public AuctionDeletedConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<AuctionDeleted> context)
        {
            Console.WriteLine("--> Consuming auction deleted: " + context.Message.Id);

            await _mediator.Send(new Delete.Command { Id = context.Message.Id });
        }
    }
}
