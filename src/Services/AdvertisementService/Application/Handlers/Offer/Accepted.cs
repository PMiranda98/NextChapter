using AdvertisementService.Domain.Entities;
using Application.Interfaces;
using Domain.DTOs.Input.Advertisement;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Offer
{
    public class Accepted
    {
        public class Command : IRequest
        {
            public required AcceptedOfferDto AcceptedOfferDto { get; set; }
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
                var advertisement = await _advertisementRepository.DetailsAdvertisement(request.AcceptedOfferDto.AdvertisementId, cancellationToken);
                if (advertisement != null)
                {
                    advertisement.Buyer = request.AcceptedOfferDto.Buyer;
                    advertisement.SoldAmount = request.AcceptedOfferDto.Amount;
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
