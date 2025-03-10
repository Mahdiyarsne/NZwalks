﻿using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Models.DTO.ImageDto
{
    public class ImageUploadRequestDto
    {
        [Required]
        public IFormFile File { get; set; }

        [Required]
        public string FileName { get; set; }

        public string? FileDescription { get; set; }

    }
}
