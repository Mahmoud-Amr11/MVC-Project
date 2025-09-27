using Microsoft.AspNetCore.Http;

namespace Demo.Service.AttachmentService
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(IFormFile imageFile, string fileName);
        Task<bool> DeleteImageAsync(string imageUrl, string fileName);
    }
}
