using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories.ImageRepository
{
    public interface IImageRepository
    {
        Task<Image> UploadAsync(Image image);
    }
}
