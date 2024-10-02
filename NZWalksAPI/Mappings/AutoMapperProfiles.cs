using AutoMapper;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.Domain.Dtos;

namespace NZWalksAPI.Mappings
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            //Crate Mapping Here 

            // CreateMap<UserDto, UserDomain>();

            CreateMap<Region, RegionDto>().ReverseMap();

            //source ->Destination

            CreateMap<AddRegionRequestDto, Region>().ReverseMap();

            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();

            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();

            CreateMap<Walk, WalkDto>().ReverseMap();

            CreateMap<Difficulty, DifficultyDto>().ReverseMap();

            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();

            CreateMap<WalkSearchDto, Walk>().ReverseMap();





        }
    }


    //public class UserDto
    //{
    //    public int FullName { get; set; }
    //}

    //public class UserDomain
    //{
    //    public int Name { get; set; }

    //}
}
