﻿using EventBus.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Consumers
{
    public class AuctionUpdatedFaultConsumer : IConsumer<Fault<AuctionUpdated>>
    {
        public async Task Consume(ConsumeContext<Fault<AuctionUpdated>> context)
        {
            Console.WriteLine("--> Consuming faulty update");
            // Simple will try to send it again. We can more with the context object that is received.
            await context.Publish(context.Message.Message);
        }
    }
}
