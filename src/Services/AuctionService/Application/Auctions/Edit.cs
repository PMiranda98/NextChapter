﻿using Application.DTOs.Input.Auction;
using Application.DTOs.Output;
using Application.Interfaces;
using AuctionService.Domain.Entities;
using AutoMapper;
using Domain.Repositories;
using MediatR;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure.Internal;

namespace AuctionService.Application.Auctions;

public class Edit
{
    public class Command : IRequest<Result<Unit>?>
    {
        public required Guid Id { get; set; }
        public required UpdateAuctionDto UpdateAuctionDto { get; set; }
        public required string User { get; set; }

    }

    public class Handler : IRequestHandler<Command, Result<Unit>?>
    {
        private readonly IAuctionsRepository _auctionsRepository;
        private readonly IMapper _mapper;
        private readonly IAuctionsPublisher _auctionsPublisher;

        public Handler(IAuctionsRepository auctionsRepository, IMapper mapper, IAuctionsPublisher auctionsPublisher)
        {
            _auctionsRepository = auctionsRepository;
            _mapper = mapper;
            _auctionsPublisher = auctionsPublisher;
        }

        public async Task<Result<Unit>?> Handle(Command request, CancellationToken cancellationToken)
        {
            var auction = await _auctionsRepository.DetailsAuction(request.Id, cancellationToken);
            if (auction == null) return null;
            if (auction.Seller != request.User)
            {
                var result = Result<Unit>.Failure("Forbid!");
                result.ErrorCode = "403";
                return result;
            }
            auction = _mapper.Map(request.UpdateAuctionDto, auction);
            var item = _mapper.Map(request.UpdateAuctionDto.Item, auction.Item);
            auction.Item = item;
            // TODO - Bug here! Its setting default values in the Item (for example public int Mileage { get; set; } gets value of zero)
            await _auctionsPublisher.PublishAuctionUpdated(auction);

            var saveChangesResult = await _auctionsRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!saveChangesResult) return Result<Unit>.Failure("Failed to update the auction!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
