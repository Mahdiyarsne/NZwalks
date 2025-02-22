using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Models.Domain;
using NZwalks.API.Models.Dto.WalksDto;
using NZwalks.API.Models.Dtos.WalksDto;
using NZwalks.API.Repositories.WalkRepositroy;

namespace NZwalks.API.Controllers
{

    public class WalksController(IMapper mapper, IWalkRepository walkRepository) : BaseApiController
    {
        //create walk
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map Dto to domain model
            var walkModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkModel);

            return Ok(mapper.Map<WalkDto>(walkModel));

        }

        //get walk
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksModel = await walkRepository.GetAllAsync();

            return Ok(mapper.Map<List<WalkDto>>(walksModel));
        }

        //get walk by id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkModel = await walkRepository.GetByIdAsync(id);

            if (walkModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkModel));
        }

        //update walk by id
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateById([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkModel = mapper.Map<Walk>(updateWalkRequestDto);

            walkModel = await walkRepository.UpdateAsync(id, walkModel);

            if (walkModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkModel));

        }

        //delete walk
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
             var deletedWalkModel = await walkRepository.DeleteAsync(id);

            if(deletedWalkModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(deletedWalkModel));
        }
    }
}
