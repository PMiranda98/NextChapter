using Application.Handlers.Advertisements;
using EventBus.Contracts;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("=====> Consuming advertisement deleted: " + context.Message.Id);

            await _mediator.Send(new Delete.Command { Id = context.Message.Id });
        }
    }
}
