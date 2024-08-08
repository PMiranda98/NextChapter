using Application.Interfaces;
using Domain.DTOs.Output;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.Items;

public class Delete
{
    public class Command : IRequest<Result<Unit>>
    {
        public required Guid Id { get; set; }
        public required string User { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IPhotoAccessor _photoAccessor;

        public Handler(IItemRepository itemRepository, IPhotoAccessor photoAccessor)
        {
            _itemRepository = itemRepository;
            _photoAccessor = photoAccessor;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            /*
            var advertisement = await _itemRepository.DetailsItem(request.Id, cancellationToken);
            if (advertisement == null) return Result<Unit>.Failure("That advertisement doesn't exist!");
            if (advertisement.Seller != request.User)
            {
                var result = Result<Unit>.Failure("Forbid!");
                result.ErrorCode = "403";
                return result;
            }
            var deletePhotoResult = await _photoAccessor.DeletePhotoAsync(advertisement.Item.Photo.Id);
            if (deletePhotoResult == null) return Result<Unit>.Failure("Failed to delete photo!");
            await _itemRepository.DeleteAdvertisement(request.Id, cancellationToken);
            await _advertisementPublisher.PublishAdvertisementDeleted(request.Id);

            var saveChangesResult = await _itemRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!saveChangesResult) return Result<Unit>.Failure("Failed to delete the advertisement!");
            return Result<Unit>.Success(Unit.Value);
            */
        }
    }
}
