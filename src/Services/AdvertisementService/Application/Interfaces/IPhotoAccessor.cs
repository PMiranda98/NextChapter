using Domain.DTOs.Output.Photos;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IPhotoAccessor
    {
        Task<PhotoUploadResult?> UploadPhotoAsync(IFormFile file);
        Task<PhotoUploadResult?> UpdatePhotoAsync(IFormFile file, string publicId);
        Task<string?> DeletePhotoAsync(string publicId);
    }
}
