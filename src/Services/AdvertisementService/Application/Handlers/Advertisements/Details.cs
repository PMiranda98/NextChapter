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
        private readonly IAdvertisementRepository _auctionsRepository;
        private readonly IMapper _mapper;

        public Handler(IAdvertisementRepository auctionsRepository, IMapper mapper)
        {
            _auctionsRepository = auctionsRepository;
            _mapper = mapper;
        }

        public async Task<Result<AdvertisementDto>?> Handle(Query request, CancellationToken cancellationToken)
        {
            var auction = await _auctionsRepository.DetailsAdvertisement(request.Id, cancellationToken);
            return Result<AdvertisementDto>.Success(_mapper.Map<AdvertisementDto>(auction));
        }
    }
}
