using AutoMapper;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;

namespace SecretSharing.Application
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ApplicationUser, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));  
        }
    }
}
