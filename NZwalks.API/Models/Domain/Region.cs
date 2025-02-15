namespace NZwalks.API.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string name { get; set; }

        public string? RegionPhotoUrl { get; set; }
    }
}
