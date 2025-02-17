using AutoMapper;
using NZwalks.API.Models.Domain;
using NZwalks.API.Models.Dto;

namespace NZwalks.API.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region,RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

        }
    }
}
