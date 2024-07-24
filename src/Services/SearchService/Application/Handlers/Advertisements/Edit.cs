using Application.DTOs.Input.Advertisement;
using AutoMapper;
using Domain.DTOs.Output;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Advertisements
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public UpdatedAdvertisementDto UpdatedAdvertisementDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IAdvertisementRepository _advertisementRepository;
            private readonly IMapper _mapper;

            public Handler(IAdvertisementRepository advertisementsRepository, IMapper mapper)
            {
                _advertisementRepository = advertisementsRepository;
                _mapper = mapper;
            }
            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var advertisement = await _advertisementRepository.DetailsAdvertisement(request.UpdatedAdvertisementDto.Id.ToString());
                if (advertisement == null) return null;
                advertisement = _mapper.Map(request.UpdatedAdvertisementDto, advertisement);

                await _advertisementRepository.UpdateAdvertisement(advertisement);
                // TODO - Error handling 
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
