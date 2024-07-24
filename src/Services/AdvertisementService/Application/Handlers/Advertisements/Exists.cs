using Domain.DTOs.Output;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Advertisements
{
    public class Exists
    {
        public class Query : IRequest<bool>
        {
            public required string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, bool>
        {
            private readonly IAdvertisementRepository _advertisementRepository;

            public Handler(IAdvertisementRepository advertisementRepository)
            {
                _advertisementRepository = advertisementRepository;
            }

            public async Task<bool> Handle(Query request, CancellationToken cancellationToken)
            {
                var advertisement = await _advertisementRepository.FindAdvertisement(request.Id, cancellationToken);
                return advertisement == null ? false : true;
            }
        }
    }
}
