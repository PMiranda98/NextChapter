using Application.DTOs.Input.Auctions;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auctions
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
                var auction = await _auctionsRepository.DetailsAuction(request.FinishedAuctionDto.AuctionId);
                if (auction != null)
                {
                    if (request.FinishedAuctionDto.ItemSold)
                    {
                        auction.Winner = request.FinishedAuctionDto.Winner;
                        auction.SoldAmount = request.FinishedAuctionDto.Amount;
                    }

                    auction.Status = auction.SoldAmount > auction.ReservePrice ? "Finished" : "ReserveNotMet";

                    await _auctionsRepository.SaveAsync(auction);
                }
            }
        }
    }
}
