using Application.Interfaces;
using Domain.DTOs.Output;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Advertisements;

public class Delete
{
    public class Command : IRequest<Result<Unit>>
    {
        public required Guid Id { get; set; }
        public required string User { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IAdvertisementPublisher _advertisementPublisher;
        private readonly IPhotoAccessor _photoAccessor;

        public Handler(IAdvertisementRepository advertisementRepository, IAdvertisementPublisher advertisementPublisher, IPhotoAccessor photoAccessor)
        {
            _advertisementRepository = advertisementRepository;
            _advertisementPublisher = advertisementPublisher;
            _photoAccessor = photoAccessor;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var advertisement = await _advertisementRepository.DetailsAdvertisement(request.Id, cancellationToken);
            if (advertisement == null) return null;
            if (advertisement.Seller != request.User)
                return Result<Unit>.Failure("Your are not the seller!");

            var deletePhotoResult = await _photoAccessor.DeletePhotoAsync(advertisement.Item.Photo.Id);
            if (deletePhotoResult == null) return Result<Unit>.Failure("Failed to delete photo!");
            await _advertisementRepository.DeleteAdvertisement(request.Id, cancellationToken);
            await _advertisementPublisher.PublishAdvertisementDeleted(request.Id);

            var saveChangesResult = await _advertisementRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!saveChangesResult) return Result<Unit>.Failure("Failed to delete the advertisement!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
