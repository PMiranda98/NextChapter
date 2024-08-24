﻿using Application.Handlers.Advertisements;
using AutoMapper;
using Domain.DTOs.Input.Advertisement;
using EventBus.Contracts;
using MassTransit;
using MediatR;

namespace Infrastructure.Consumers.OfferService
{
    public class AdvertisementFinishedConsumer : IConsumer<OfferAccepted>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public AdvertisementFinishedConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<OfferAccepted> context)
        {
            Console.WriteLine("=====> Consuming advertisement finished");

            var finishedAdvertisementDto = _mapper.Map<FinishedAdvertisementDto>(context.Message);
            await _mediator.Send(new Finished.Command { FinishedAdvertisementDto = finishedAdvertisementDto });
        }
    }
}
