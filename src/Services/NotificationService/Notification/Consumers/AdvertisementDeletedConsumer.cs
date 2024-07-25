using EventBus.Contracts;
using MassTransit;
using Microsoft.AspNetCore.SignalR;
using Notification.Hubs;

namespace Notification.Consumers
{
    public class AdvertisementDeletedConsumer : IConsumer<AdvertisementDeleted>
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public AdvertisementDeletedConsumer(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task Consume(ConsumeContext<AdvertisementDeleted> context)
        {
            Console.WriteLine("=====> Advertisement deleted consumed: {id}", context.Message.Id);

            // We simple going to send to any connected client.
            // "AdvertisementDeleted" is the method that the client will listen for.
            await _hubContext.Clients.All.SendAsync("AdvertisementDeleted", context.Message);
        }
    }
}
