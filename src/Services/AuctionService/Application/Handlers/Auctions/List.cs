using Application.DTOs.Output;
using Application.DTOs.Output.Auction;
using AuctionService.Persistence.Data;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers.Auctions;

public class List
{
    public class Query : IRequest<Result<List<AuctionDto>>> { }

    public class Handler : IRequestHandler<Query, Result<List<AuctionDto>>>
    {
        private readonly IAuctionsRepository _auctionsRepository;
        private readonly IMapper _mapper;

        public Handler(IAuctionsRepository auctionsRepository, IMapper mapper)
        {
            _auctionsRepository = auctionsRepository;
            _mapper = mapper;
        }
        public async Task<Result<List<AuctionDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var auctions = await _auctionsRepository.ListAuctions(cancellationToken);
            return Result<List<AuctionDto>>.Success(_mapper.Map<List<AuctionDto>>(auctions));
        }
    }
}
