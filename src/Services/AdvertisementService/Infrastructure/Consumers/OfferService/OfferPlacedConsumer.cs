using Application.Handlers.Offer;
using AutoMapper;
using Domain.DTOs.Input.Offer;
using EventBus.Contracts;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Consumers.OfferService
{
    public class OfferPlacedConsumer : IConsumer<OfferPlaced>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OfferPlacedConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<OfferPlaced> context)
        {
            Console.WriteLine("--> Consuming offer placed: " + context.Message.Id);

            var offerPlacedDto = _mapper.Map<OfferPlacedDto>(context.Message);
            await _mediator.Send(new Placed.Command { OfferPlacedDto = offerPlacedDto });
        }
    }
}
