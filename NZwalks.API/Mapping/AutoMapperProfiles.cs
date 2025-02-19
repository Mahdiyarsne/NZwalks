using AutoMapper;
using NZwalks.API.Models.Dtos;
using NZwalks.API.Models.Domain;
using NZwalks.API.Models.Dto.WalksDto;
using NZwalks.API.Models.Dtos.WalksDto;



namespace NZwalks.API.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();


        }
    }
}
