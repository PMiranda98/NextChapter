using Application.DTOs.Output;
using Application.Interfaces;
using AuctionService.Persistence.Data;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Auctions;

public class Delete
{
    public class Command : IRequest<Result<Unit>?>
    {
        public required Guid Id { get; set; }
        public required string User { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>?>
    {
        private readonly IAuctionsRepository _auctionsRepository;
        private readonly IAuctionsPublisher _auctionsPublisher;

        public Handler(IAuctionsRepository auctionsRepository, IAuctionsPublisher auctionsPublisher)
        {
            _auctionsRepository = auctionsRepository;
            _auctionsPublisher = auctionsPublisher;
        }

        public async Task<Result<Unit>?> Handle(Command request, CancellationToken cancellationToken)
        {
            var auction = await _auctionsRepository.DetailsAuction(request.Id, cancellationToken);
            if (auction == null) return null;
            if (auction.Seller != request.User)
            {
                var result = Result<Unit>.Failure("Forbid!");
                result.ErrorCode = "403";
                return result;
            }
            _auctionsRepository.DeleteAuction(request.Id, cancellationToken);
            await _auctionsPublisher.PublishAuctionDeleted(request.Id);

            var saveChangesResult = await _auctionsRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!saveChangesResult) return Result<Unit>.Failure("Failed to delete the auction!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
