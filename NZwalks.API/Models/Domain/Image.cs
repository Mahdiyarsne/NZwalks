﻿using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.FileProviders;

namespace NZwalks.API.Models.Domain
{
    public class Image
    {

        public Guid Id { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }

        public string FileName { get; set; }

        public string? FileDescription { get; set; }

        public string FileExtension { get; set; }


        public long FileSizeInBytes { get; set; }

        public string FilePath { get; set; }
    }
}
