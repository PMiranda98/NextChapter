using EventBus.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Consumers.Faults
{
    public class OfferAcceptedFaultConsumer : IConsumer<Fault<OfferAccepted>>
    {
        public async Task Consume(ConsumeContext<Fault<OfferAccepted>> context)
        {
            Console.WriteLine("=====> Consuming faulty offer accepted");
            // Simple will try to send it again. We can do more with the context object that is received.
            await context.Publish(context.Message.Message);
        }
    }
}
