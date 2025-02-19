using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Models.Domain;
using NZwalks.API.Models.Dto.WalksDto;
using NZwalks.API.Models.Dtos.WalksDto;
using NZwalks.API.Repositories.WalkRepositroy;

namespace NZwalks.API.Controllers
{
    
    public class WalksController(IMapper mapper,IWalkRepository walkRepository) :BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map Dto to domain model
            var walkModel = mapper.Map < Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkModel);

            return Ok(mapper.Map<WalkDto>(walkModel));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksModel= await walkRepository.GetAllAsync();

            return Ok(mapper.Map<List<WalkDto>>(walksModel));
        }
    }
}
