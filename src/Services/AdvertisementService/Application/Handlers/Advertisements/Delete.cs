using Application.Interfaces;
using Domain.DTOs.Output;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Advertisements;

public class Delete
{
    public class Command : IRequest<Result<Unit>?>
    {
        public required Guid Id { get; set; }
        public required string User { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>?>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IAdvertisementPublisher _advertisementPublisher;

        public Handler(IAdvertisementRepository advertisementRepository, IAdvertisementPublisher advertisementPublisher)
        {
            _advertisementRepository = advertisementRepository;
            _advertisementPublisher = advertisementPublisher;
        }

        public async Task<Result<Unit>?> Handle(Command request, CancellationToken cancellationToken)
        {
            var advertisement = await _advertisementRepository.DetailsAdvertisement(request.Id, cancellationToken);
            if (advertisement == null) return null;
            if (advertisement.Seller != request.User)
            {
                var result = Result<Unit>.Failure("Forbid!");
                result.ErrorCode = "403";
                return result;
            }
            _advertisementRepository.DeleteAdvertisement(request.Id, cancellationToken);
            await _advertisementPublisher.PublishAdvertisementDeleted(request.Id);

            var saveChangesResult = await _advertisementRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!saveChangesResult) return Result<Unit>.Failure("Failed to delete the advertisement!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
