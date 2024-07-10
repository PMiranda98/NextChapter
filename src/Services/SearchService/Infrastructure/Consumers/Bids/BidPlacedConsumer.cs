﻿using Application.Bids;
using Application.DTOs.Input.Bids;
using AutoMapper;
using EventBus.Contracts;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Consumers.Bids
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
            Console.WriteLine("--> Consuming bid placed");

            var bidPlacedDto = _mapper.Map<BidPlacedDto>(context.Message);
            await _mediator.Send(new Placed.Command { BidPlacedDto = bidPlacedDto });
        }
    }
}
