using AutoMapper;
using NZwalks.API.Data;
using NZwalks.API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Repositories;
using NZwalks.API.Models.Domain;
using NZwalks.API.CustomActionFilters;
using Microsoft.AspNetCore.Authorization;

namespace NZwalks.API.Controllers
{
    [Authorize]
    public class RegionsController(IRegionRepository regionRepository
        ,IMapper mapper
        ) : BaseApiController

    {
        //get all  region
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regionsModel = await regionRepository.GetAllAsync();

            return Ok(mapper.Map<List<RegionDto>>(regionsModel));
        }

        //get region by id
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

        //create region
        [HttpPost]
        [VaildateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Convert Dto to domain model
            var regionModel = mapper.Map<Region>(addRegionRequestDto);

            regionModel = await regionRepository.CreateAsync(regionModel);

            //map domain model back to dto
            var regionDto = mapper.Map<RegionDto>(regionModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        //update region
        [HttpPut]
        [Route("{id:Guid}")]
        [VaildateModel]
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


        //delete region
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
