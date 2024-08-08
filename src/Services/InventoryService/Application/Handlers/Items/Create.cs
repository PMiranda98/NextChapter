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
        private readonly IItemRepository _advertisementRepository;
        private readonly IPhotoAccessor _photoAccessor;

        public Handler(IMapper mapper, IItemRepository advertisementRepository, IPhotoAccessor photoAccessor)
        {
            _mapper = mapper;
            _advertisementRepository = advertisementRepository;
            _photoAccessor = photoAccessor;
        }

        public async Task<Result<CreatedItemDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            /*
            var advertisement = _mapper.Map<Advertisement>(request.CreateItemDto);
            advertisement.Seller = request.Seller;

            var photoUploadResult = await _photoAccessor.UploadPhotoAsync(request.File);
            if (photoUploadResult == null) return Result<CreatedAdvertisementDto>.Failure("Failed to save photo!");
            advertisement.Item.Photo = new Photo { Id = photoUploadResult.PublicId, Url = photoUploadResult.Url };

            await _itemRepository.CreateAdvertisement(advertisement, cancellationToken);
            await _advertisementPublisher.PublishAdvertisementCreated(advertisement);

            var result = await _itemRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<CreatedAdvertisementDto>.Failure("Failed to create Advertisement!");

            var createdAdvertisementDto = _mapper.Map<CreatedAdvertisementDto>(advertisement);
            return Result<CreatedAdvertisementDto>.Success(createdAdvertisementDto);
            */
        }
    }
}
