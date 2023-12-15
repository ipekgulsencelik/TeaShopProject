using AutoMapper;
using TeaShop.DTO.DTOs.AccountDTOs;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.API.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<RegisterDTO, AppUser>().ReverseMap();
            CreateMap<LoginDTO, AppUser>().ReverseMap();
        }
    }
}