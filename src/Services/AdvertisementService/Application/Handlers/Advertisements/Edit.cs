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

public class Edit
{
    public class Command : IRequest<Result<Unit>>
    {
        public required Guid Id { get; set; }
        public required UpdateAdvertisementDto UpdateAdvertisementDto { get; set; }
        public required IFormFile File { get; set; }
        public required string User { get; set; }

    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IMapper _mapper;
        private readonly IAdvertisementPublisher _advertisementPublisher;
        private readonly IPhotoAccessor _photoAccessor;

        public Handler(IAdvertisementRepository advertisementRepository, IMapper mapper, IAdvertisementPublisher advertisementPublisher, IPhotoAccessor photoAccessor)
        {
            _advertisementRepository = advertisementRepository;
            _mapper = mapper;
            _advertisementPublisher = advertisementPublisher;
            _photoAccessor = photoAccessor;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var advertisement = await _advertisementRepository.DetailsAdvertisement(request.Id, cancellationToken);
            if (advertisement == null) return null;
            if (advertisement.Seller != request.User)
                return Result<Unit>.Failure("You are not the seller!");

            var photoUpdateResult = await _photoAccessor.UpdatePhotoAsync(request.File, advertisement.Item.Photo.Id);
            if (photoUpdateResult == null) return Result<Unit>.Failure("Failed to save photo!");
            advertisement.Item.Photo.Url = photoUpdateResult.Url;

            advertisement = _mapper.Map(request.UpdateAdvertisementDto, advertisement);
            advertisement.UpdateAt = DateTime.UtcNow;

            await _advertisementPublisher.PublishAdvertisementUpdated(advertisement);

            var saveChangesResult = await _advertisementRepository.SaveChangesAsync(cancellationToken) > 0;
            if (!saveChangesResult) return Result<Unit>.Failure("Failed to update the advertisement!");
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
