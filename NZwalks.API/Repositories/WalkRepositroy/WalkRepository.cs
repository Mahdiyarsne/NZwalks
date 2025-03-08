using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;
using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories.WalkRepositroy
{
    public class WalkRepository(NZWalksDbContext context) : IWalkRepository
    {
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await context.Walks.AddAsync(walk);
            await context.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await context.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            context.Walks.Remove(existingWalk);
             await context.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy=null, bool isAscending = true , 
            int pageNumber = 1, int pageSize = 50)
        {
            var walks= context.Walks.Include("Difficulty").Include("Region").AsQueryable();

            //filtering
            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if(filterOn.Equals("Name",StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            //sorting
            if(string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if(sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if(sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            //pagination
            var skipResult = (pageNumber - 1) * pageSize;
            return await walks.Skip(skipResult).Take(pageSize).ToListAsync();

            //return await context.Walks
            //    .Include("Difficulty")
            //    .Include("Region")
            //    .ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await context.Walks
                 .Include("Difficulty")
                 .Include("Region")
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await context.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Region = walk.Region;
            existingWalk.Region = walk.Region;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.Description = walk.Description;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;

            await context.SaveChangesAsync();

            return existingWalk;
        }
    }
}
