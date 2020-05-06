using AutoMapper;
using ProductTracking.BL.DTO;
using ProductTracking.MVC.Models;

namespace ProductTracking.MVC.MappingProfiles
{
    public class MvcMappingProfile : Profile
    {
        public MvcMappingProfile()
        {
            CreateMap<ProductDto, ProductViewModel>().ReverseMap();
            CreateMap<UserDto, UserModel>().ReverseMap();
            CreateMap<ProductEditViewModel, ProductDto>().ReverseMap();
        }
    }
}
