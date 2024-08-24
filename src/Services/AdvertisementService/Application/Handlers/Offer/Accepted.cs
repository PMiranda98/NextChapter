using AdvertisementService.Domain.Entities;
using Application.Interfaces;
using Domain.DTOs.Input.Offer;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Offer
{
    public class Accepted
    {
        public class Command : IRequest
        {
            public required OfferAcceptedDto OfferAcceptedDto { get; set; }
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
                if (Guid.TryParse(request.OfferAcceptedDto.AdvertisementId, out Guid advertisementId))
                {
                    var advertisement = await _advertisementRepository.DetailsAdvertisement(advertisementId, cancellationToken);
                    if (advertisement != null)
                    {
                        advertisement.Buyer = request.OfferAcceptedDto.Buyer;
                        advertisement.SoldAmount = request.OfferAcceptedDto.Amount;
                        advertisement.Status = AdvertisementStatus.Sold;
                        advertisement.UpdateAt = DateTime.UtcNow;
                        advertisement.EndedAt = DateTime.UtcNow;

                        await _advertisementPublisher.PublishAdvertisementUpdated(advertisement);
                        await _advertisementRepository.SaveChangesAsync(cancellationToken);
                    }
                }
            }
        }
    }
}
