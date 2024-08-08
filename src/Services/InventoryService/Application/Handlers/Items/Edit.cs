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
            throw new NotImplementedException();
            /*
            var advertisement = await _itemRepository.DetailsItem(request.Id, cancellationToken);
            if (advertisement == null) return null;
            if (advertisement.Seller != request.User)
            {
                var result = Result<Unit>.Failure("Forbid!");
                result.ErrorCode = "403";
                return result;
            }

            var photoUpdateResult = await _photoAccessor.UpdatePhotoAsync(request.File, advertisement.Item.Photo.Id);
            if (photoUpdateResult == null) return Result<Unit>.Failure("Failed to save photo!");
            advertisement.Item.Photo.Url = photoUpdateResult.Url;

            advertisement = _mapper.Map(request.UpdateItemDto, advertisement);
            advertisement.UpdateAt = DateTime.UtcNow;

            await _advertisementPublisher.PublishAdvertisementUpdated(advertisement);

            var saveChangesResult = await _itemRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!saveChangesResult) return Result<Unit>.Failure("Failed to update the advertisement!");
            return Result<Unit>.Success(Unit.Value);
            */
        }
    }
}
