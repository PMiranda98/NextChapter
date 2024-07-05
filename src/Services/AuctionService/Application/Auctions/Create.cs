using Application.DTOs.Input.Auction;
using Application.DTOs.Output;
using Application.Interfaces;
using AuctionService.Domain.Entities;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace AuctionService.Application.Auctions;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public Auction Auction { get; set; }
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
            _auctionsRepository.CreateAuction(request.Auction, cancellationToken);
            await _auctionsPublisher.PublishAuctionCreated(request.Auction);

            var result = await _auctionsRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure("Failed to create Auction!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
