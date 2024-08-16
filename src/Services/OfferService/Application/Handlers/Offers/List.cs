using AutoMapper;
using Domain.DTOs.Input;
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
    public class List
    {
        public class Query : IRequest<Result<SearchOutputDTO<OfferDto>>>
        {
            public SearchInputDTO SearchInputDTO { get; set; }
            public required string Username { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<SearchOutputDTO<OfferDto>>>
        {
            private readonly IOfferRepository _offerRepository;
            private readonly IMapper _mapper;

            public Handler(IOfferRepository offerRepository, IMapper mapper)
            {
                _offerRepository = offerRepository;
                _mapper = mapper;
            }
            public async Task<Result<SearchOutputDTO<OfferDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var offers = await _offerRepository.ListOffers(request.SearchInputDTO, request.Username, cancellationToken);
                return Result<SearchOutputDTO<OfferDto>>.Success(_mapper.Map<SearchOutputDTO<OfferDto>>(offers));
            }
        }
    }
}
