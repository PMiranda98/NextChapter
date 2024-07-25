using EventBus.Contracts;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using Notification.Hubs;

namespace Notification.Consumers
{
    public class OfferPlacedConsumer : IConsumer<OfferPlaced>
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public OfferPlacedConsumer(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task Consume(ConsumeContext<OfferPlaced> context)
        {
            Console.WriteLine("=====> Offer placed consumed: {id}", context.Message.Id);

            // We simple going to send to any connected client.
            // "OfferPlaced" is the method that the client will listen for.
            await _hubContext.Clients.All.SendAsync("OfferPlaced", context.Message);
        }
    }

}
