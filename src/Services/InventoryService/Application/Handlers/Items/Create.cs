using Application.Interfaces;
using AutoMapper;
using Domain.DTOs.Input.Item;
using Domain.DTOs.Output;
using Domain.DTOs.Output.Item;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers.Items;

public class Create
{
    public class Command : IRequest<Result<CreatedItemDto>>
    {
        public required CreateItemDto CreateItemDto { get; set; }
        public required string Owner { get; set; }
        public required IFormFile File { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<CreatedItemDto>>
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;
        private readonly IPhotoAccessor _photoAccessor;

        public Handler(IMapper mapper, IItemRepository itemRepository, IPhotoAccessor photoAccessor)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            _photoAccessor = photoAccessor;
        }

        public async Task<Result<CreatedItemDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<Item>(request.CreateItemDto);
            item.Owner = request.Owner;

            var photoUploadResult = await _photoAccessor.UploadPhotoAsync(request.File);
            if (photoUploadResult == null) return Result<CreatedItemDto>.Failure("Failed to save photo!");
            item.Photo = new Photo { Id = photoUploadResult.PublicId, Url = photoUploadResult.Url };

            await _itemRepository.CreateItem(item, cancellationToken);

            var result = await _itemRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<CreatedItemDto>.Failure("Failed to create Item!");

            var createdItemDto = _mapper.Map<CreatedItemDto>(item);
            return Result<CreatedItemDto>.Success(createdItemDto);
        }
    }
}
