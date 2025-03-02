using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace NZwalks.API.Data
{
    public class NZWalksAuthDbContext(DbContextOptions<NZWalksAuthDbContext> options) : IdentityDbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "aa7094fb-cbd8-41f2-8fa2-cfd2d7e9fae5";
            var writerRoleId = "8bfcb13a-376f-4dd9-ba2b-c0e572df9cee";

            var roles = new List<IdentityRole>
            {

                new IdentityRole
                {
                   Id = readerRoleId,
                   ConcurrencyStamp= readerRoleId,
                   Name= "Reader",
                   NormalizedName="Reader".ToUpper()
                },

                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name= "Writer",
                    NormalizedName="Writer".ToUpper(),
                }

            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
