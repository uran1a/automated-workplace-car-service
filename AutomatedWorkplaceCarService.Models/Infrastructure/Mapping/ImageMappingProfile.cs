using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.DTOs.Image;
using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping
{
    public class ImageMappingProfile : Profile
    {
        public ImageMappingProfile()
        {
            CreateMap<CreateImageDTO, Image>()
                 .ForMember(
                    dest => dest.FileName,
                    opt => opt.MapFrom(src => src.FileName))
                 .ForMember(
                    dest => dest.ContentType,
                    opt => opt.MapFrom(src => src.ContentType))
                 .ForMember(
                    dest => dest.Content,
                    opt => opt.MapFrom(src => src.Content))
                 .ForMember(
                    dest => dest.CarId,
                    opt => opt.MapFrom(src => src.CarId))
                 .ForMember(
                    dest => dest.ApplicationId,
                    opt => opt.MapFrom(src => src.ApplicationId));
            CreateMap<Image, ImageDTO>();
                 
        }
    }
}
