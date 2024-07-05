using Application.Auctions;
using Application.DTOs.Input.Auctions;
using AutoMapper;
using Domain.Entities;
using EventBus.Contracts;
using MassTransit;
using MediatR;

namespace Infrastructure.Consumers
{
    public class AuctionUpdatedConsumer : IConsumer<AuctionUpdated>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AuctionUpdatedConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<AuctionUpdated> context)
        {
            Console.WriteLine("--> Consuming auction updated: " + context.Message.Id);


            // TODO - Bug here! This creates an new Auction instance and the default values will interfer in the next mappings inside of the Edit handler.
            var updatedAuctionDto = _mapper.Map<UpdatedAuctionDto>(context.Message);
            await _mediator.Send(new Edit.Command { UpdatedAuctionDto = updatedAuctionDto });
        }
    }
}
