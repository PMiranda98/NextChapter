using AutoMapper;
using Domain.DTOs.Input;
using Domain.DTOs.Output;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Auctions
{
    public class List
    {
        public class Query : IRequest<Result<SearchOutputDTO<Auction>>>
        {
            public SearchInputDTO SearchInputDTO { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<SearchOutputDTO<Auction>>>
        {
            private readonly IAuctionsRepository _auctionsRepository;
            private readonly IMapper _mapper;

            public Handler(IAuctionsRepository auctionsRepository, IMapper mapper)
            {
                _auctionsRepository = auctionsRepository;
                _mapper = mapper;
            }
            public async Task<Result<SearchOutputDTO<Auction>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _auctionsRepository.SearchAuctions(request.SearchInputDTO);
                return Result<SearchOutputDTO<Auction>>.Success(_mapper.Map<SearchOutputDTO<Auction>>(result));
            }
        }
    }
}
