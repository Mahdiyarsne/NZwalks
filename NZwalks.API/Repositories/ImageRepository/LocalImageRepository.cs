using NZwalks.API.Data;
using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories.ImageRepository
{
    public class LocalImageRepository(IWebHostEnvironment webHostEnvironment , IHttpContextAccessor httpContextAccessor , NZWalksDbContext context) : IImageRepository
    {
        public async Task<Image> UploadAsync(Image image)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");

            //upload image to local path
          using var stream = new FileStream(localFilePath, FileMode.Create);

            await image.File.CopyToAsync(stream);

            //file path
            var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            //images save to database
            await context.Images.AddAsync(image);
            await context.SaveChangesAsync();

            return image;
        }
    }
}
