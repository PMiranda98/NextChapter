using Application.DTOs.Input.Auction;
using Application.DTOs.Input.Bid;
using Application.Interfaces;
using Domain.Repositories;
using MassTransit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Bids
{
    public class Placed
    {
        public class Command : IRequest
        {
            public required BidPlacedDto BidPlacedDto { get; set; }
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
                var auction = await _auctionsRepository.DetailsAuction(request.BidPlacedDto.AuctionId, cancellationToken);
                if (auction != null)
                {
                    if (auction.CurrentHighBid == null
                        || request.BidPlacedDto.BidStatus.Contains("Accepted")
                        && request.BidPlacedDto.Amount > auction.CurrentHighBid)
                    {
                        auction.CurrentHighBid = request.BidPlacedDto.Amount;

                        await _auctionsRepository.SaveChangesAsync(cancellationToken);
                    }
                }
            }
        }
    }
}
