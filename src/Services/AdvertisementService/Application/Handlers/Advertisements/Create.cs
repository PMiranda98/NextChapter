using AdvertisementService.Domain.Entities;
using Application.Interfaces;
using AutoMapper;
using Domain.DTOs.Input.Advertisement;
using Domain.DTOs.Output;
using Domain.DTOs.Output.Advertisement;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Handlers.Advertisements;

public class Create
{
    public class Command : IRequest<Result<CreatedAdvertisementDto>>
    {
        public required CreateAdvertisementDto CreateAdvertisementDto { get; set; }
        public required IFormFile File { get; set; }
        public required string Seller { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<CreatedAdvertisementDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IAdvertisementPublisher _advertisementPublisher;
        private readonly IPhotoAccessor _photoAccessor;

        public Handler(IMapper mapper, IAdvertisementRepository advertisementRepository, IAdvertisementPublisher advertisementPublisher, IPhotoAccessor photoAccessor)
        {
            _mapper = mapper;
            _advertisementRepository = advertisementRepository;
            _advertisementPublisher = advertisementPublisher;
            _photoAccessor = photoAccessor;
        }

        public async Task<Result<CreatedAdvertisementDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            var advertisement = _mapper.Map<Advertisement>(request.CreateAdvertisementDto);
            advertisement.Seller = request.Seller;

            var photoUploadResult = await _photoAccessor.UploadPhotoAsync(request.File);
            if (photoUploadResult == null) return Result<CreatedAdvertisementDto>.Failure("Failed to save photo!");
            advertisement.Item.Photo = new Photo { Id = photoUploadResult.PublicId, Url = photoUploadResult.Url };

            await _advertisementRepository.CreateAdvertisement(advertisement, cancellationToken);
            await _advertisementPublisher.PublishAdvertisementCreated(advertisement);

            var result = await _advertisementRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!result) return Result<CreatedAdvertisementDto>.Failure("Failed to create Advertisement!");

            var createdAdvertisementDto = _mapper.Map<CreatedAdvertisementDto>(request.CreateAdvertisementDto);
            createdAdvertisementDto.Id = advertisement.Id;
            createdAdvertisementDto.Item.Photo = advertisement.Item.Photo;
            return Result<CreatedAdvertisementDto>.Success(createdAdvertisementDto);
        }
    }
}
