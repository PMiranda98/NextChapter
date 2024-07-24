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
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IMapper _mapper;

        public Handler(IAdvertisementRepository advertisementRepository, IMapper mapper)
        {
            _advertisementRepository = advertisementRepository;
            _mapper = mapper;
        }
        public async Task<Result<List<AdvertisementDto>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var advertisements = await _advertisementRepository.ListAdvertisement(cancellationToken);
            return Result<List<AdvertisementDto>>.Success(_mapper.Map<List<AdvertisementDto>>(advertisements));
        }
    }
}
