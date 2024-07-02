using Application.DTOs.Input.Auction;
using Application.DTOs.Output;
using AuctionService.Domain.Entities;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace AuctionService.Application.Auctions;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public CreateAuctionDto CreateAuctionDto { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly IMapper _mapper;
        private readonly IAuctionsRepository _auctionsRepository;

        public Handler(IMapper mapper, IAuctionsRepository auctionsRepository)
        {
            _mapper = mapper;
            _auctionsRepository = auctionsRepository;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var auction = new Auction();
            auction = _mapper.Map(request.CreateAuctionDto, auction);

            var result = await _auctionsRepository.CreateAuction(auction, cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure("Failed to create Auction!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
