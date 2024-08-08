using Application.Interfaces;
using AutoMapper;
using Domain.DTOs.Input.Item;
using Domain.DTOs.Output;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers.Items;

public class Edit
{
    public class Command : IRequest<Result<Unit>>
    {
        public required Guid Id { get; set; }
        public required UpdateItemDto UpdateItemDto { get; set; }
        public required IFormFile File { get; set; }
        public required string User { get; set; }

    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoAccessor _photoAccessor;

        public Handler(IItemRepository itemRepository, IMapper mapper, IPhotoAccessor photoAccessor)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
            _photoAccessor = photoAccessor;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {

            
            var item = await _itemRepository.DetailsItem(request.Id, cancellationToken);
            if (item == null) return Result<Unit>.Failure("That item doesn't exist!");
            if (item.Owner != request.User)
            {
                var result = Result<Unit>.Failure("Forbid!");
                result.ErrorCode = "403";
                return result;
            }

            var photoUpdateResult = await _photoAccessor.UpdatePhotoAsync(request.File, item.Photo.Id);
            if (photoUpdateResult == null) return Result<Unit>.Failure("Failed to save photo!");
            item.Photo.Url = photoUpdateResult.Url;

            item = _mapper.Map(request.UpdateItemDto, item);
            item.UpdateAt = DateTime.UtcNow;

            var saveChangesResult = await _itemRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!saveChangesResult) return Result<Unit>.Failure("Failed to update the item!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
