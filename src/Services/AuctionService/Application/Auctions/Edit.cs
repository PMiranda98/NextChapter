using Application.DTOs.Input.Auction;
using Application.DTOs.Output;
using Application.Interfaces;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace AuctionService.Application.Auctions;

public class Edit
{
    public class Command : IRequest<Result<Unit>?>
    {
        public Guid Id { get; set; }
        public UpdateAuctionDto UpdateAuctionDto { get; set; }
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
            auction = _mapper.Map(request.UpdateAuctionDto, auction);

            _auctionsPublisher.PublishAuctionUpdated(auction);
            var result = await _auctionsRepository.UpdateAuction(cancellationToken) > 0;
            if (!result) return Result<Unit>.Failure("Failed to update the auction!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
