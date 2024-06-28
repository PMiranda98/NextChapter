using AuctionService.Application.Core;
using AuctionService.Domain.DTOs.Auction;
using AuctionService.Persistence.Data;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AuctionService.Application.Auctions;

public class List
    {
        public class Query : IRequest<Result<List<AuctionDto>>> {}

        public class Handler : IRequestHandler<Query, Result<List<AuctionDto>>>
        {
            private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public Handler(DataContext dataContext, IMapper mapper)
            {
                _dataContext = dataContext;
            _mapper = mapper;
        }
            public async Task<Result<List<AuctionDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                // TODO - Check the Eager, Lazy and Explict Loading of EF.
                var auctions = await _dataContext.Auctions.Include(x => x.Item).OrderBy(x => x.Item.Make).ToListAsync(cancellationToken);
                return Result<List<AuctionDto>>.Success(_mapper.Map<List<AuctionDto>>(auctions));
            }
        }
    }
