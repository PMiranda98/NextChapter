﻿using Application.Interfaces;
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
        private readonly IAdvertisementPublisher _advertisementPublisher;

        public Handler(IAdvertisementRepository advertisementRepository, IAdvertisementPublisher advertisementPublisher)
            {
                _advertisementRepository = advertisementRepository;
            _advertisementPublisher = advertisementPublisher;
        }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                if (Guid.TryParse(request.OfferPlacedDto.AdvertisementId, out Guid advertisementId))
                {
                    var advertisement = await _advertisementRepository.DetailsAdvertisement(advertisementId, cancellationToken);
                    if (advertisement != null)
                    {
                        advertisement.NumberOfOffers++;
                        await _advertisementRepository.SaveChangesAsync(cancellationToken);
                    }
                }
            }
        }
    }

