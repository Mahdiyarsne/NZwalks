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
    }
}
