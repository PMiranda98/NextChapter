using EventBus.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Consumers.Faults
{
    public class OfferPlacedFaultConsumer : IConsumer<Fault<OfferPlaced>>
    {
        public async Task Consume(ConsumeContext<Fault<OfferPlaced>> context)
        {
            Console.WriteLine("--> Consuming faulty offer placed");
            // Simple will try to send it again. We can do more with the context object that is received.
            await context.Publish(context.Message.Message);
        }
    }
}
