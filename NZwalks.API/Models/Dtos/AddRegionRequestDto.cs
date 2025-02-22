using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.Dtos
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3,ErrorMessage ="Code has to be a minimum of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be a maxium of 3 characters")]
        public  string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maxium of 100 characters")]
        public string Name { get; set; }

        public string? RegionPhotoUrl { get; set; }


    }
}
