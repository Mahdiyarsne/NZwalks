using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;
using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories.WalkRepositroy
{
    public class WalkRepository(NZWalkerDbContext context) : IWalkRepository
    {
        public async Task<Walk> CreateAsync(Walk walk)
        {
             await context.Walks.AddAsync(walk);
            await context.SaveChangesAsync();   

            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await context.Walks
                .Include(x =>x.Difficulty)
                .Include(y =>y.Region)
                .ToListAsync();
        }
    }
}
