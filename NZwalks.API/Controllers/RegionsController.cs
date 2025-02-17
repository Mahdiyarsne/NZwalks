
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZwalks.API.Data;
using NZwalks.API.Models.Domain;
using NZwalks.API.Models.Dto;
using NZwalks.API.Repositories;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController(NZWalkerDbContext context,
        IRegionRepository regionRepository,
        IMapper mapper
        ) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsModel = await regionRepository.GetAllAsync();

            return Ok(mapper.Map<List<RegionDto>>(regionsModel));
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            var regionsModel = await regionRepository.GetByIdAsync(id);

            if (regionsModel == null)
            {
                return NotFound();
            }

            //return dtos
            return Ok(mapper.Map<RegionDto>(regionsModel));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionModel = mapper.Map<Region>(addRegionRequestDto);


            regionModel = await regionRepository.CreateAsync(regionModel);

            //map domain model back to dto
            var regionDto = mapper.Map<RegionDto>(regionModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //map model to dto

            var regionModel = mapper.Map<Region>(updateRegionRequestDto);


            regionModel = await regionRepository.UpdateAsync(id, regionModel);

            if (regionModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionModel));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionModel = await regionRepository.DeleteAsync(id);

            if (regionModel == null)

            {
                return NotFound();
            }



            return Ok(mapper.Map<RegionDto>(regionModel));
        }

    }
}
