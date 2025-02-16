namespace NZwalks.API.Models.Dto
{
    public class UpdateRegionRequestDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string? RegionPhotoUrl { get; set; }
    }
}
