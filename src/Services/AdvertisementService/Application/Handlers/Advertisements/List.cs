using AutoMapper;
using Domain.DTOs.Output;
using Domain.DTOs.Output.Advertisement;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Advertisements;

public class List
{
    public class Query : IRequest<Result<List<AdvertisementDto>>> { }

    public class Handler : IRequestHandler<Query, Result<List<AdvertisementDto>>>
    {
        private readonly IAdvertisementRepository _auctionsRepository;
        private readonly IMapper _mapper;

        public Handler(IAdvertisementRepository auctionsRepository, IMapper mapper)
        {
            _auctionsRepository = auctionsRepository;
            _mapper = mapper;
        }
        public async Task<Result<List<AdvertisementDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var auctions = await _auctionsRepository.ListAdvertisement(cancellationToken);
            return Result<List<AdvertisementDto>>.Success(_mapper.Map<List<AdvertisementDto>>(auctions));
        }
    }
}
