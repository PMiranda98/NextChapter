using Application.Interfaces;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Offer
{
    public class Deleted
    {
        public class Command : IRequest
        {
            public required string AdvertisementId { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IAdvertisementRepository _advertisementRepository;
            private readonly IAdvertisementPublisher _advertisementPublisher;

            public Handler(IAdvertisementRepository advertisementRepository, IAdvertisementPublisher advertisementPublisher)
            {
                _advertisementRepository = advertisementRepository;
                _advertisementPublisher = advertisementPublisher;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var advertisement = await _advertisementRepository.DetailsAdvertisement(request.AdvertisementId, cancellationToken);
                if (advertisement != null)
                {
                    advertisement.NumberOfOffers = advertisement.NumberOfOffers - 1;
                    advertisement.UpdateAt = DateTime.UtcNow;

                    await _advertisementPublisher.PublishAdvertisementUpdated(advertisement);
                    await _advertisementRepository.SaveChangesAsync(cancellationToken);
                }
            }
        }
    }
}
