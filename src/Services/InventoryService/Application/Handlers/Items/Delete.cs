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
            var item = await _itemRepository.DetailsItem(request.Id, cancellationToken);
            if (item == null) return null;
            if (item.Owner != request.User)
                return Result<Unit>.Failure("You are not the owner!");

            var deletePhotoResult = await _photoAccessor.DeletePhotoAsync(item.Photo.Id);
            if(deletePhotoResult == null) return Result<Unit>.Failure("Failed to delete photo!");
            
            await _itemRepository.DeleteItem(request.Id, cancellationToken);

            var saveChangesResult = await _itemRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!saveChangesResult) return Result<Unit>.Failure("Failed to delete the item!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
