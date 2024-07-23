using AdvertisementService.Domain.Entities;
using Domain.DTOs.Input.Advertisement;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Advertisements
{
    public class Finished
    {
        public class Command : IRequest
        {
            public required FinishedAdvertisementDto FinishedAdvertisementDto { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IAdvertisementRepository _auctionsRepository;

            public Handler(IAdvertisementRepository auctionsRepository)
            {
                _auctionsRepository = auctionsRepository;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var auction = await _auctionsRepository.DetailsAdvertisement(request.FinishedAdvertisementDto.AdvertisementId, cancellationToken);
                if (auction != null)
                {
                    if (request.FinishedAdvertisementDto.ItemSold)
                    {
                        auction.Buyer = request.FinishedAdvertisementDto.Buyer;
                        auction.SoldAmount = request.FinishedAdvertisementDto.Amount;
                    }

                    auction.Status = AdvertisementStatus.Finished;

                    await _auctionsRepository.SaveChangesAsync(cancellationToken);
                }
            }
        }
    }
}
