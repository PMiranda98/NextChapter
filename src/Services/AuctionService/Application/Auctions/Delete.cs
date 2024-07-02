using Application.DTOs.Output;
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

        public Handler(IAuctionsRepository auctionsRepository)
        {
            _auctionsRepository = auctionsRepository;
        }

        public async Task<Result<Unit>?> Handle(Command request, CancellationToken cancellationToken)
        {
            var result = await _auctionsRepository.DeleteAuction(request.Id, cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete the auction!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
