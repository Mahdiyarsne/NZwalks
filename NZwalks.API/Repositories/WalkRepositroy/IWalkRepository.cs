using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories.WalkRepositroy
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(); 
    }
}
