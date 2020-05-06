using AutoMapper;
using ProductTracking.BL.DTO;
using ProductTracking.DAL.Entities;

namespace ProductTracking.BL.MappingProfiles
{
    public class BLMappingProfile : Profile
    {
        public BLMappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<RealizationPlace, RealizationPlaceDto>().ReverseMap();
        }
    }
}
