﻿using Application.DTOs.Output;
using Application.DTOs.Output.Auction;
using AuctionService.Persistence.Data;
using AutoMapper;
using Domain.Repositories;
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
        private readonly IAuctionsRepository _auctionsRepository;
        private readonly IMapper _mapper;

        public Handler(IAuctionsRepository auctionsRepository, IMapper mapper)
        {
            _auctionsRepository = auctionsRepository;
            _mapper = mapper;
        }

        public async Task<Result<AuctionDto>?> Handle(Query request, CancellationToken cancellationToken)
        {
            var auction = await _auctionsRepository.DetailsAuction(request.Id, cancellationToken);
            return Result<AuctionDto>.Success(_mapper.Map<AuctionDto>(auction));
        }
    }
}
