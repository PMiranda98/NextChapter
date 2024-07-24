using Application.DTOs.Input.Offers;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Offers
{
    public class Placed : IRequest
    {
        public class Command : IRequest
        {
            public required PlacedOfferDto PlacedOfferDto { get; set; }
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
                var advertisement = await _advertisementRepository.DetailsAdvertisement(request.PlacedOfferDto.AdvertisementId);
                if (advertisement != null)
                {
                    advertisement.NumberOfOffers++;
                    await _advertisementRepository.SaveAsync(advertisement);
                }
            }
        }
    }
}
