using Domain.DTOs.Output;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Advertisements
{
    public class Delete
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IOfferRepository _offerRepository;

            public Handler(IOfferRepository offerRepository)
            {
                _offerRepository = offerRepository;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var offers = await _offerRepository.ListOffersByAdvertisement(request.Id, cancellationToken);
                foreach (var offer in offers)
                {
                    if(offer.Status == OfferStatus.Live) offer.Status = OfferStatus.Rejected;
                }
                await _offerRepository.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
