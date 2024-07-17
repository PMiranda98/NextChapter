using Application.Handlers.Bids;
using AutoMapper;
using Domain.DTOs.Input.Bid;
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
    public class BidPlacedConsumer : IConsumer<BidPlaced>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public BidPlacedConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<BidPlaced> context)
        {
            Console.WriteLine("--> Consuming bid placed: " + context.Message.Id);

            var bidPlacedDto = _mapper.Map<BidPlacedDto>(context.Message);
            await _mediator.Send(new Placed.Command { BidPlacedDto = bidPlacedDto });
        }
    }
}
