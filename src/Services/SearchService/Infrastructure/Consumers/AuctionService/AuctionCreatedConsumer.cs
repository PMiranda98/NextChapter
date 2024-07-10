using Application.Handlers.Auctions;
using AutoMapper;
using Domain.Entities;
using EventBus.Contracts;
using MassTransit;
using MediatR;

namespace Infrastructure.Consumers.AuctionService
{
    public class AuctionCreatedConsumer : IConsumer<AuctionCreated>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AuctionCreatedConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<AuctionCreated> context)
        {
            Console.WriteLine("--> Consuming auction created: " + context.Message.Id);

            var auction = _mapper.Map<Auction>(context.Message);
            await _mediator.Send(new Create.Command { Auction = auction });
        }
    }
}
