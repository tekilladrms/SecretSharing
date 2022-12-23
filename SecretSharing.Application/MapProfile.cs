using AutoMapper;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;

namespace SecretSharing.Application
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserProfile, UserProfileDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Guid))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.Value))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.Value))
                .ForMember(dest => dest.Documents, opt => opt.MapFrom(src => src.Documents));

            CreateMap<Document, DocumentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Guid))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value));
        }
    }
}
