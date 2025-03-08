using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Models.Domain;
using NZwalks.API.Models.DTO.ImageDto;
using NZwalks.API.Repositories.ImageRepository;

namespace NZwalks.API.Controllers
{
    public class ImagesController(IImageRepository imageRepository) : BaseApiController
    {
        //Upload images
        [HttpPost]
        [Route("Upload")]

        public async Task<IActionResult> Upload([FromForm]ImageUploadRequestDto request)
        {
            VaildateFileUpload(request);

            if (ModelState.IsValid)
            {
                var imageModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileDescription = request.FileDescription,
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,

                };

                //User repository to upload image
                await imageRepository.UploadAsync(imageModel);
                return Ok(imageModel);
            }

            return BadRequest(ModelState);
        }

        private void VaildateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extensions");
            }
            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB , please upload smaller size file");
            }
        }
    }
}
