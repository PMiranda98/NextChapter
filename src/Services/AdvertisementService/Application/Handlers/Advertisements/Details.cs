using AutoMapper;
using Domain.DTOs.Output;
using Domain.DTOs.Output.Advertisement;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Advertisements;

public class Details
{
    public class Query : IRequest<Result<AdvertisementDto>>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<AdvertisementDto>?>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IMapper _mapper;

        public Handler(IAdvertisementRepository advertisementRepository, IMapper mapper)
        {
            _advertisementRepository = advertisementRepository;
            _mapper = mapper;
        }

        public async Task<Result<AdvertisementDto>?> Handle(Query request, CancellationToken cancellationToken)
        {
            var advertisement = await _advertisementRepository.DetailsAdvertisement(request.Id, cancellationToken);
            return Result<AdvertisementDto>.Success(_mapper.Map<AdvertisementDto>(advertisement));
        }
    }
}
