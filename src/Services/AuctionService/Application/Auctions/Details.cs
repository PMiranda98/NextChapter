using Application.DTOs.Output;
using Application.DTOs.Output.Auction;
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
            // Lazy Loading - If we only have this line this is consider Lazy Loading, the auction wont have the Item property filled.
            // This is used when we are confident that we don't need to use the related entites instantly.
            /*
                // var auction = await _dataContext.Auctions.FindAsync(request.Id, cancellationToken);
             */

            // Explicit loading - Works like lazy loading, but after the first call, more calls are made depending on the navigation properties that we want to fill.
            // Provides access to change tracking information and loading information for all reference (i.e non-collection) navigation properties of this entity.
            /*
                // if (auction != null)
                // await _dataContext.Entry(auction).Reference(x => x.Item).LoadAsync(cancellationToken);
             */

            // Provides access to change tracking information and loading information for all collection navigation properties of this entity
            /*
                //if (auction != null)
                // _dataContext.Entry(auction).Collections(x => x.Items).LoadAsync(cancelationToken);
             */
            // Eager Loading
            var auction = await _dataContext.Auctions.Include(x => x.Item).Where(x => x.Id == request.Id).FirstAsync();

            return Result<AuctionDto>.Success(_mapper.Map<AuctionDto>(auction));
        }
    }
}
