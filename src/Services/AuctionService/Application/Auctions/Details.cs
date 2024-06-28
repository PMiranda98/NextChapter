using AuctionService.Application.Core;
using AuctionService.Domain.DTOs.Auction;
using AuctionService.Persistence.Data;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Application.Auctions;

public class Details
{
    public class Query : IRequest<Result<AuctionDto>>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<AuctionDto>?>
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public Handler(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<Result<AuctionDto>?> Handle(Query request, CancellationToken cancellationToken)
        {
            // TODO - Check the Eager, Lazy and Explict Loading of EF.
            var auction = await _dataContext.Auctions.FindAsync(request.Id, cancellationToken);
            return Result<AuctionDto>.Success(_mapper.Map<AuctionDto>(auction));
        }
    }
}
