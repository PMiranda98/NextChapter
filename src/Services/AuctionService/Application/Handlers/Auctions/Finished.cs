using AuctionService.Domain.Entities;
using Domain.DTOs.Input.Auction;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Auctions
{
    public class Finished
    {
        public class Command : IRequest
        {
            public required FinishedAuctionDto FinishedAuctionDto { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IAuctionsRepository _auctionsRepository;

            public Handler(IAuctionsRepository auctionsRepository)
            {
                _auctionsRepository = auctionsRepository;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var auction = await _auctionsRepository.DetailsAuction(request.FinishedAuctionDto.AuctionId, cancellationToken);
                if (auction != null)
                {
                    if (request.FinishedAuctionDto.ItemSold)
                    {
                        auction.Winner = request.FinishedAuctionDto.Winner;
                        auction.SoldAmount = request.FinishedAuctionDto.Amount;
                    }

                    auction.Status = auction.SoldAmount > auction.ReservePrice ? Status.Finished : Status.ReserveNotMet;

                    await _auctionsRepository.SaveChangesAsync(cancellationToken);
                }
            }
        }
    }
}
