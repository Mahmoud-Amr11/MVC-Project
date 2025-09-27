

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Demo.Service.AttachmentService
{
    public  class FileService :IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imageFolderPath;
        private readonly string _fileExtensions = ".jpg,.jpeg,.png,.gif";

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _imageFolderPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "images");
        }


        public async Task<string> SaveImageAsync(IFormFile imageFile, string fileName)
        {
            if (imageFile == null || imageFile.Length == 0)
                return null;

            var fileExtension = Path.GetExtension(imageFile.FileName).ToLower();
            if (!_fileExtensions.Contains(fileExtension))
                return null;

            var imageName = $"{Guid.NewGuid()}{Path.GetExtension(imageFile.FileName)}";
            var filePath = Path.Combine(_imageFolderPath, fileName, imageName);

            using var stream = File.Create(filePath);
            await imageFile.CopyToAsync(stream);

            return imageName;

        }

        public Task<bool> DeleteImageAsync(string imageUrl, string fileName)
        {
            if (string.IsNullOrWhiteSpace(imageUrl) || string.IsNullOrWhiteSpace(fileName))
                return Task.FromResult(false);

            imageUrl = Path.Combine(_imageFolderPath, fileName, imageUrl);

            if (File.Exists(imageUrl))
            {
                File.Delete(imageUrl);
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}
