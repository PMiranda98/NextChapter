﻿using Application.Interfaces;
using AuctionService.Domain.Entities;
using AutoMapper;
using Domain.DTOs.Input.Auction;
using Domain.DTOs.Output;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Auctions;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public required CreateAuctionDto CreateAuctionDto { get; set; }
        public required string Seller { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IAuctionsRepository _auctionsRepository;
        private readonly IAuctionsPublisher _auctionsPublisher;

        public Handler(IMapper mapper, IAuctionsRepository auctionsRepository, IAuctionsPublisher auctionsPublisher)
        {
            _mapper = mapper;
            _auctionsRepository = auctionsRepository;
            _auctionsPublisher = auctionsPublisher;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var auction = _mapper.Map<Auction>(request.CreateAuctionDto);
            auction.Seller = request.Seller;
            _auctionsRepository.CreateAuction(auction, cancellationToken);
            await _auctionsPublisher.PublishAuctionCreated(auction);

            var result = await _auctionsRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure("Failed to create Auction!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
