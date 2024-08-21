using AdvertisementService.Domain.Entities;
using Domain.DTOs.Input.Advertisement;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Advertisements
{
    public class Sold
    {
        public class Command : IRequest
        {
            public required SoldAdvertisementDto SoldAdvertisementDto { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IAdvertisementRepository _advertisementRepository;

            public Handler(IAdvertisementRepository advertisementRepository)
            {
                _advertisementRepository = advertisementRepository;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var advertisement = await _advertisementRepository.DetailsAdvertisement(request.SoldAdvertisementDto.AdvertisementId, cancellationToken);
                if (advertisement != null)
                {
                    if (request.SoldAdvertisementDto.ItemSold)
                    {
                        advertisement.Buyer = request.SoldAdvertisementDto.Buyer;
                        advertisement.SoldAmount = request.SoldAdvertisementDto.Amount;
                    }

                    advertisement.Status = AdvertisementStatus.Sold;

                    await _advertisementRepository.SaveChangesAsync(cancellationToken);
                }
            }
        }
    }
}
