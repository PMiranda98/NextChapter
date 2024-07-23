using Domain.DTOs.Input.Offer;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Offer;
    public class Placed
    {
        public class Command : IRequest
        {
            public required OfferPlacedDto OfferPlacedDto { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IAdvertisementRepository _advertisementRepository;

            public Handler(IAdvertisementRepository advertisementRepository)
            {
                _advertisementRepository = advertisementRepository;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var advertisement = await _advertisementRepository.DetailsAdvertisement(request.OfferPlacedDto.AdvertisementId, cancellationToken);
                if (advertisement != null)
                {
                    advertisement.NumberOfOffers++;
                    await _advertisementRepository.SaveChangesAsync(cancellationToken);
                }
            }
        }
    }

