using Microsoft.EntityFrameworkCore;
using NZwalks.API.Models.Domain;

namespace NZwalks.API.Data
{
    public class NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : DbContext(options)
    {

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty>Difficulties { get; set; }

        //Seed data for Difficulties

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>
            {
                new Difficulty
                {
                    Id =Guid.Parse("7b2ce3d4-ac0e-4ba9-8e2f-0893e3e07494") ,
                    Name="Easy"
                },

                 new Difficulty
                {
                    Id =Guid.Parse("f4a3f97d-1ba2-460c-8e04-df12b9c42993") ,
                    Name="Medium"
                },

                  new Difficulty
                {
                    Id = Guid.Parse("9acb62ce-7179-4f50-b87d-890103cf0afd"),
                    Name="Hard"
                }

            };

            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //Seed Regions to the database
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("efeab7f7-2132-4234-8898-7e22ed7c65b8"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionPhotoUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("2ad74d70-03a4-48b2-b588-2536eda00b7c"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionPhotoUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("7ef4e2d0-e544-4b12-a2bd-d2b84a9f9df2"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionPhotoUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("4dad0347-c7c1-45ff-aba7-ea3446cbae3c"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionPhotoUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("5f5a68b1-3a42-4cd5-9b4c-2fe15b75045b"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionPhotoUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.Parse("8828a69c-4b39-4c59-85f4-0c787b57e034"),
                    Name = "Southland",
                    Code = "STL",
                    RegionPhotoUrl = null
                },

            };

            modelBuilder.Entity<Region>().HasData(regions);

        }

    }
}
