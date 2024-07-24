using EventBus.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Consumers.Faults
{
    public class AdvertisementDeletedFaultConsumer : IConsumer<Fault<AdvertisementDeleted>>
    {
        public async Task Consume(ConsumeContext<Fault<AdvertisementDeleted>> context)
        {
            Console.WriteLine("=====> Consuming faulty creation");
            // Simple will try to send it again. We can do more with the context object that is received.
            await context.Publish(context.Message.Message);
        }
    }
}
