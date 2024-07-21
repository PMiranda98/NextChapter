using Domain.DTOs.Output;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Advertisements
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Domain.Entities.Advertisement Advertisement { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly IAdvertisementRepository _advertisementRepository;

            public Handler(IAdvertisementRepository advertisementRepository)
            {
                _advertisementRepository = advertisementRepository;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                await _advertisementRepository.CreateAdvertisement(request.Advertisement);
                // TODO - Error handling 
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
