using Application.DTOs.Input.Auction;
using Application.Handlers.Auctions;
using AutoMapper;
using EventBus.Contracts;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Consumers.BidService
{
    public class AuctionFinishedConsumer : IConsumer<AuctionFinished>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AuctionFinishedConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<AuctionFinished> context)
        {
            Console.WriteLine("--> Consuming auction finished: " + context.Message.AuctionId);

            var finishedAuctionDto = _mapper.Map<FinishedAuctionDto>(context.Message);
            await _mediator.Send(new Finished.Command { FinishedAuctionDto = finishedAuctionDto });
        }
    }
}
