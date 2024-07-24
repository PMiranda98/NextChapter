using Domain.DTOs.Output;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Advertisement
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public string Id { get; set; }
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
                await _advertisementRepository.DeleteAdvertisement(request.Id);
                // TODO - Error handling 
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
