using AutoMapper;
using Domain.DTOs.Output;
using Domain.DTOs.Output.Offer;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Offers
{
    public class ListByAdvertisement
    {
        public class Query : IRequest<Result<List<OfferDto>>> 
        {
            public required string AdvertisementId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<OfferDto>>>
        {
            private readonly IOfferRepository _offerRepository;
            private readonly IMapper _mapper;

            public Handler(IOfferRepository offerRepository, IMapper mapper)
            {
                _offerRepository = offerRepository;
                _mapper = mapper;
            }
            public async Task<Result<List<OfferDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var offers = await _offerRepository.ListOffersByAdvertisement(request.AdvertisementId, cancellationToken);
                return Result<List<OfferDto>>.Success(_mapper.Map<List<OfferDto>>(offers));
            }
        }
    }
}
