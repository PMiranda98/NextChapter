using Application.DTOs.Input.Bids;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bids
{
    public class Placed : IRequest
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
                var auction = await _auctionsRepository.DetailsAuction(request.BidPlacedDto.AuctionId);
                if (auction != null)
                {
                    if (request.BidPlacedDto.BidStatus.Contains("Accepted")
                        && request.BidPlacedDto.Amount > auction.CurrentHighBid)
                    {
                        auction.CurrentHighBid = request.BidPlacedDto.Amount;

                        await _auctionsRepository.SaveAsync(auction);
                    }
                }
            }
        }
    }
}
