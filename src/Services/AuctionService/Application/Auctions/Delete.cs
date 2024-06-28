using AuctionService.Application.Core;
using AuctionService.Persistence.Data;
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
        private readonly DataContext _dataContext;

        public Handler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Result<Unit>?> Handle(Command request, CancellationToken cancellationToken)
        {
            var auction = await _dataContext.Auctions.FindAsync(request.Id);
            if (auction == null) return null;
            _dataContext.Auctions.Remove(auction);
            
            // TODO - Check if the Item is deleted too.

            var result = await _dataContext.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure("Failed to delete the auction!");
            
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
