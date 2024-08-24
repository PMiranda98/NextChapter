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
    public class OfferDeletedConsumer : IConsumer<OfferDeleted>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public OfferDeletedConsumer(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public async Task Consume(ConsumeContext<OfferDeleted> context)
        {
            Console.WriteLine("=====> Consuming offer deleted: " + context.Message.AdvertisementId);

            await _mediator.Send(new Deleted.Command { AdvertisementId = context.Message.AdvertisementId });
        }
    }
}
