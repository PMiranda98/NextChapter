using AutoMapper;
using Domain.DTOs.Input;
using Domain.DTOs.Output;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Advertisements
{
    public class List
    {
        public class Query : IRequest<Result<SearchOutputDTO<Domain.Entities.Advertisement>>>
        {
            public SearchInputDTO SearchInputDTO { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<SearchOutputDTO<Domain.Entities.Advertisement>>>
        {
            private readonly IAdvertisementRepository _advertisementRepository;
            private readonly IMapper _mapper;

            public Handler(IAdvertisementRepository advertisementRepository, IMapper mapper)
            {
                _advertisementRepository = advertisementRepository;
                _mapper = mapper;
            }
            public async Task<Result<SearchOutputDTO<Domain.Entities.Advertisement>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _advertisementRepository.SearchAdvertisement(request.SearchInputDTO);
                return Result<SearchOutputDTO<Domain.Entities.Advertisement>>.Success(_mapper.Map<SearchOutputDTO<Domain.Entities.Advertisement>>(result));
            }
        }
    }
}
