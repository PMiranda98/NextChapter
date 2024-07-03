using Application.DTOs.Output;
using Application.Interfaces;
using AuctionService.Persistence.Data;
using Domain.Repositories;
using MediatR;

namespace AuctionService.Application.Auctions;

public class Delete
{
    public class Command : IRequest<Result<Unit>?>
    {
        public Guid Id { get; set; }
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
            _auctionsRepository.DeleteAuction(request.Id, cancellationToken);
            await _auctionsPublisher.PublishAuctionDeleted(request.Id);

            var result = await _auctionsRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete the auction!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
