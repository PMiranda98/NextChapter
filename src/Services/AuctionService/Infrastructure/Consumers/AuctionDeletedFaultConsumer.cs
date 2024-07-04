using EventBus.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Consumers
{
    public class AuctionDeletedFaultConsumer : IConsumer<Fault<AuctionDeleted>>
    {
        public async Task Consume(ConsumeContext<Fault<AuctionDeleted>> context)
        {
            Console.WriteLine("--> Consuming faulty creation");
            // Simple will try to send it again. We can more with the context object that is received.
            await context.Publish(context.Message.Message);
        }
    }
}
