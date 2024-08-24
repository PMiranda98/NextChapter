using Application.Interfaces;
using AutoMapper;
using Domain.DTOs.Input.Offer;
using Domain.DTOs.Output;
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
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public required Guid Id { get; set; }
            public required UpdateOfferDto UpdateOfferDto { get; set; }
            public required string User { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IOfferRepository _offerRepository;
            private readonly IMapper _mapper;
            private readonly IOfferPublisher _offerPublisher;

            public Handler(IOfferRepository offerRepository, IMapper mapper, IOfferPublisher offerPublisher)
            {
                _offerRepository = offerRepository;
                _mapper = mapper;
                _offerPublisher = offerPublisher;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var offer = await _offerRepository.DetailsOffer(request.Id, cancellationToken);
                if (offer == null) return null;

                offer = _mapper.Map(request.UpdateOfferDto, offer);
                offer.UpdateAt = DateTime.UtcNow;

                if(offer.Status == OfferStatus.Accepted)
                    await _offerPublisher.PublishOfferAccepted(offer);

                await _offerRepository.UpdateOffer(offer, cancellationToken);
                var saveChangesResult = await _offerRepository.SaveChangesAsync(cancellationToken) > 0;
                if (!saveChangesResult) return Result<Unit>.Failure("Failed to update the offer!");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
