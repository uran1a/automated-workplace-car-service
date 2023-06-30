using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Application, ApplicationDTO>().ReverseMap();
            CreateMap<Application, ApplicationCardDTO>()
                .ForMember(
                    dest => dest.ServiceName,
                    opt => opt.MapFrom(src => src.Service.Name))
                .ForMember(
                    dest => dest.StageName,
                    opt => opt.MapFrom(src => src.Stage.Name))
                .ForMember(
                    dest => dest.ModelName,
                    opt => opt.MapFrom(src => src.Car.Model.Name))
                .ForMember(
                    dest => dest.BrandName,
                    opt => opt.MapFrom(src => src.Car.Brand.Name))
                .ForMember(
                    dest => dest.ImageCarContent,
                    opt => opt.MapFrom(src => src.Car.Images[0].Content));
        }
    }
}
