﻿using Domain.DTOs.Input.Advertisement;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            private readonly IAdvertisementRepository _advertisementRepository;

            public Handler(IAdvertisementRepository advertisementRepository)
            {
                _advertisementRepository = advertisementRepository;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var advertisement = await _advertisementRepository.DetailsAdvertisement(request.FinishedAdvertisementDto.AdvertisementId);
                if (advertisement != null)
                {
                    if (request.FinishedAdvertisementDto.ItemSold)
                    {
                        advertisement.Buyer = request.FinishedAdvertisementDto.Buyer;
                        advertisement.SoldAmount = request.FinishedAdvertisementDto.Amount;
                    }

                    advertisement.Status = "Finished";

                    await _advertisementRepository.SaveAsync(advertisement);
                }
            }
        }
    }
}
