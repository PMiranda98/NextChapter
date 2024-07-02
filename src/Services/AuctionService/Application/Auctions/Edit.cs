using Application.DTOs.Input.Auction;
using Application.DTOs.Output;
using AuctionService.Persistence.Data;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Application.Auctions;

public class Edit
{
    public class Command : IRequest<Result<Unit>?>
    {
        public Guid Id { get; set; }
        public UpdateAuctionDto UpdateAuctionDto { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>?>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public Handler(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<Unit>?> Handle(Command request, CancellationToken cancellationToken)
        {
            // Eager Loading
            var auction = await _dataContext.Auctions.Include(x => x.Item).Where(x => x.Id == request.Id).FirstAsync();
            if (auction == null) return null;
            _mapper.Map(request.UpdateAuctionDto, auction);

            var result = await _dataContext.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure("Failed to update the auction!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
