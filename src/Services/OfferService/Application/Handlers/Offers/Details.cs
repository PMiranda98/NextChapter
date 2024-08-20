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
    public class Details
    {
        public class Query : IRequest<Result<OfferDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<OfferDto>>
        {
            private readonly IOfferRepository _offerRepository;
            private readonly IMapper _mapper;

            public Handler(IOfferRepository offerRepository, IMapper mapper)
            {
                _offerRepository = offerRepository;
                _mapper = mapper;
            }

            public async Task<Result<OfferDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var offer = await _offerRepository.DetailsOffer(request.Id, cancellationToken);
                return Result<OfferDto>.Success(_mapper.Map<OfferDto>(offer));
            }
        }
    }
}
