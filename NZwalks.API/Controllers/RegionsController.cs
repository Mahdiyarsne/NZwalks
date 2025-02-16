using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZwalks.API.Data;
using NZwalks.API.Models.Domain;
using NZwalks.API.Models.Dto;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController(NZWalkerDbContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = context.Regions.ToList();

            var regionsDto = new List<RegionDto>();

            foreach (var region in regions)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionPhotoUrl = region.RegionPhotoUrl
                });
            }

            return Ok (regions);

        }


        [HttpGet]
        [Route("{id:Guid}")]

        public IActionResult GetById([FromRoute] Guid id)
        {

             var regions = context.Regions.FirstOrDefault(x => x.Id == id);

            if(regions == null)
            {
                return NotFound();
            }

            var regionsDto = new RegionDto
            {
                Id = regions.Id,
                Name = regions.Name,
                Code = regions.Code,
                RegionPhotoUrl = regions.RegionPhotoUrl
            };

            return Ok(regions);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var regionModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionPhotoUrl = addRegionRequestDto.RegionPhotoUrl
            };

            context.Regions.Add(regionModel);

            context.SaveChanges();

            var regionDto = new RegionDto
            {
                Id = regionModel.Id,
                Name = regionModel.Name,
                Code = regionModel.Code,
                RegionPhotoUrl=regionModel.RegionPhotoUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute]Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionModel = context.Regions.FirstOrDefault(x => x.Id == id);

            if (regionModel == null)  
            { 
               return NotFound();
            
            }

            regionModel.Code = updateRegionRequestDto.Code;
            regionModel.Name = updateRegionRequestDto.Name;
            regionModel.RegionPhotoUrl = updateRegionRequestDto.RegionPhotoUrl;

            var regionDto = new RegionDto
            {
                Id = regionModel.Id,
                Name = regionModel.Name,
                Code = regionModel.Code,
                RegionPhotoUrl = regionModel.RegionPhotoUrl
            };

            context.SaveChanges();

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id) 
        { 
          var regionModel= context.Regions.FirstOrDefault(x => x.Id == id);
          
            if(regionModel == null)

            {
                return NotFound();
            }

            context.Regions.Remove(regionModel);
            context.SaveChanges();

            //Map Domain Model to Dto
            var regionDto = new RegionDto
            {
                RegionPhotoUrl = regionModel.RegionPhotoUrl,
                Code = regionModel.Code,
                Name = regionModel.Name,
                Id = regionModel.Id
            };


            return Ok(regionModel);
        }

    }
}
