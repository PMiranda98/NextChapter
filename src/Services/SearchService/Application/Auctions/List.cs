using Application.Core;
using Application.DTOs.Input.Auctions;
using Application.DTOs.Output.Auctions;
using AutoMapper;
using Domain.Repositories;
using Domain.Repositories.Models;
using MediatR;

namespace Application.Auctions
{
    public class List
    {
        public class Query : IRequest<Result<SearchAuctionsOutputDTO>> 
        {
            public SearchAuctionsInputDTO SearchAuctionsInputDTO { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<SearchAuctionsOutputDTO>>
        {
            private readonly IAuctionsRepository _auctionsRepository;
            private readonly IMapper _mapper;

            public Handler(IAuctionsRepository auctionsRepository, IMapper mapper)
            {
                _auctionsRepository = auctionsRepository;
                _mapper = mapper;
            }
            public async Task<Result<SearchAuctionsOutputDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _auctionsRepository.SearchAuctions(_mapper.Map<SearchAuctionsParams>(request.SearchAuctionsInputDTO));
                return Result<SearchAuctionsOutputDTO>.Success(_mapper.Map<SearchAuctionsOutputDTO>(result));
            }
        }
    }
}
