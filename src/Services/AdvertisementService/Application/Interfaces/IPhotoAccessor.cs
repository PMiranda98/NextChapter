using Domain.DTOs.Output.Photos;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadResult?> UploadPhotoAsync(IFormFile file);
        Task<string?> DeletePhotoAsync(string publicId);
    }
}
