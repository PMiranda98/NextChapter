using Application.Interfaces;
using AutoMapper;
using Domain.DTOs.Input.Offer;
using Domain.DTOs.Output;
using Domain.DTOs.Output.Offer;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Offers
{
    public class Create
    {
        public class Command : IRequest<Result<CreatedOfferDto>>
        {
            public required CreateOfferDto CreateOfferDto { get; set; }
            public required string Buyer { get; set; }
            public Guid AdvertisementId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<CreatedOfferDto>>
        {
            private readonly IMapper _mapper;
            private readonly IOfferRepository _offerRepository;
            private readonly IOfferPublisher _offerPublisher;

            public Handler(IMapper mapper, IOfferRepository offerRepository, IOfferPublisher offerPublisher)
            {
                _mapper = mapper;
                _offerRepository = offerRepository;
                _offerPublisher = offerPublisher;
            }

            public async Task<Result<CreatedOfferDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var offer = _mapper.Map<Offer>(request.CreateOfferDto);
                offer.Buyer = request.Buyer;

                // TODO : Make a gRPC call to the advertisements service to check if the advertisement exists.

                await _offerRepository.CreateOffer(offer, cancellationToken);
                await _offerPublisher.PublishOfferPlaced(offer);

                var result = await _offerRepository.SaveChangesAsync(cancellationToken) > 0;
                if (!result) return Result<CreatedOfferDto>.Failure("Failed to create Offer!");

                var createdOfferDto = _mapper.Map<CreatedOfferDto>(request.CreateOfferDto);
                createdOfferDto.Id = offer.Id;
                return Result<CreatedOfferDto>.Success(createdOfferDto);
            }
        }
    }
}
