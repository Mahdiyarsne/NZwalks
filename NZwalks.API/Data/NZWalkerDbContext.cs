﻿using Microsoft.EntityFrameworkCore;
using NZwalks.API.Models.Domain;

namespace NZwalks.API.Data
{
    public class NZWalkerDbContext(DbContextOptions options) : DbContext(options)
    {

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty>Difficulties { get; set; }

    }
}
