using EventBus.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Consumers.Faults
{
    public class AdvertisementUpdatedFaultConsumer : IConsumer<Fault<AdvertisementUpdated>>
    {
        public async Task Consume(ConsumeContext<Fault<AdvertisementUpdated>> context)
        {
            Console.WriteLine("--> Consuming faulty update");
            // Simple will try to send it again. We can do more with the context object that is received.
            await context.Publish(context.Message.Message);
        }
    }
}
