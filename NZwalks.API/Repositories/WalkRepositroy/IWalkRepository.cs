﻿using NZwalks.API.Models.Domain;

namespace NZwalks.API.Repositories.WalkRepositroy
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber=1 , int pageSize=50); 
        Task<Walk?> GetByIdAsync (Guid id);
        Task<Walk?> UpdateAsync (Guid id , Walk walk);
        Task<Walk?> DeleteAsync (Guid id);
    }
}
