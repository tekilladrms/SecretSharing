using AutoMapper;
using SecretSharing.Application.DTO;
using SecretSharing.Domain.Entities;

namespace SecretSharing.Application
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Document, DocumentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Guid))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value));
            //.ForMember(dest => dest.File.FileName, opt => opt.MapFrom(src => src.S3Info.FileName))
            //.ForMember(dest => dest.File.ContentDisposition, opt => opt.MapFrom(src => src.S3Info.LocalPath));

            CreateMap<ApplicationUser, UserInfoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
                
        }
    }
}
