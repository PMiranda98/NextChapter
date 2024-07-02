using Application.DTOs.Input.Auction;
using Application.DTOs.Output;
using AuctionService.Persistence.Data;
using AutoMapper;
using Domain.Repositories;
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
        private readonly IAuctionsRepository _auctionsRepository;
        private readonly IMapper _mapper;

        public Handler(IAuctionsRepository auctionsRepository, IMapper mapper)
        {
            _auctionsRepository = auctionsRepository;
            _mapper = mapper;
        }

        public async Task<Result<Unit>?> Handle(Command request, CancellationToken cancellationToken)
        {
            var auction = await _auctionsRepository.DetailsAuction(request.Id, cancellationToken);
            if (auction == null) return null;
            auction = _mapper.Map(request.UpdateAuctionDto, auction);
            // Eager Loading
            //var auction = await _dataContext.Auctions.Include(x => x.Item).Where(x => x.Id == request.Id).FirstAsync();

            var result = await _auctionsRepository.UpdateAuction(request.Id, auction, cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure("Failed to update the auction!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
