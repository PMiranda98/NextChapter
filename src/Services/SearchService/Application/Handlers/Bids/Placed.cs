using Application.DTOs.Input.Bids;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Bids
{
    public class Placed : IRequest
    {
        public class Command : IRequest
        {
            public required PlacedBidDto PlacedBidDto { get; set; }
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
                var auction = await _auctionsRepository.DetailsAuction(request.PlacedBidDto.AuctionId);
                if (auction != null)
                {
                    if (request.PlacedBidDto.BidStatus.Contains("Accepted")
                        && request.PlacedBidDto.Amount > auction.CurrentHighBid)
                    {
                        auction.CurrentHighBid = request.PlacedBidDto.Amount;

                        await _auctionsRepository.SaveAsync(auction);
                    }
                }
            }
        }
    }
}
