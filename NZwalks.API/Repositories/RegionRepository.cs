using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;
using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories
{
    public class RegionRepository(NZWalksDbContext context) : IRegionRepository
    {
        public async Task<Region> CreateAsync(Region region)
        {
            await context.Regions.AddAsync(region);
            await context.SaveChangesAsync();

            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
          var region = await context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null) 
            { 
              return null;
            }
            context.Regions.Remove(region);

            await context.SaveChangesAsync();

            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await context.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await context.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var exisitRegion = await context.Regions.FirstOrDefaultAsync(x => x.Id
            == id);

            if(exisitRegion == null)
            {
                return null;
            }

            exisitRegion.Code = region.Code;
            exisitRegion.Name = region.Name;
            exisitRegion.RegionPhotoUrl = region.RegionPhotoUrl;

            await context.SaveChangesAsync();

            return exisitRegion;    
        }
    }
}
