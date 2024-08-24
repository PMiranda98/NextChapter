using Application.Interfaces;
using Domain.DTOs.Output;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Offers
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public required Guid Id { get; set; }
            public required string User { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IOfferRepository _offerRepository;
            private readonly IOfferPublisher _offerPublisher;

            public Handler(IOfferRepository offerRepository, IOfferPublisher offerPublisher)
            {
                _offerRepository = offerRepository;
                _offerPublisher = offerPublisher;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var offer = await _offerRepository.DetailsOffer(request.Id, cancellationToken);
                if (offer == null) return null;
                if (offer.Sender != request.User)
                    return Result<Unit>.Failure("You are not the sender!");

                await _offerRepository.DeleteOffer(request.Id, cancellationToken);

                await _offerPublisher.PublishOfferAccepted(offer);

                var saveChangesResult = await _offerRepository.SaveChangesAsync(cancellationToken) > 0;
                if (!saveChangesResult) return Result<Unit>.Failure("Failed to delete the offer!");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
