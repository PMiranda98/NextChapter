using Application.DTOs.Input.Auction;
using Application.DTOs.Output;
using AuctionService.Domain.Entities;
using AuctionService.Persistence.Data;
using AutoMapper;
using Domain.Interfaces;
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
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IAuctionPublisher _auctionPublisher;

        public Handler(DataContext dataContext, IMapper mapper, IAuctionPublisher auctionPublisher)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _auctionPublisher = auctionPublisher;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var auction = new Auction();
            auction = _mapper.Map(request.CreateAuctionDto, auction);

            _dataContext.Auctions.Add(auction);
            var result = await _dataContext.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure("Failed to create Auction!");

            await _auctionPublisher.AuctionCreatedPublisher(auction);
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
