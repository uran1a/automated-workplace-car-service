using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutoMapper;

namespace AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            CreateMap<Car, CarDTO>()
                .ForMember(
                    dest => dest.BrandId,
                    opt => opt.MapFrom(src => src.BrandId))
                .ForMember(
                    dest => dest.Brand,
                    opt => opt.MapFrom(src => src.Brand))
                .ForMember(
                    dest => dest.ModelId,
                    opt => opt.MapFrom(src => src.ModelId))
                .ForMember(
                    dest => dest.Model,
                    opt => opt.MapFrom(src => src.Model))
                .ForMember(
                    dest => dest.TransmissionId,
                    opt => opt.MapFrom(src => src.TransmissionId))
                .ForMember(
                    dest => dest.Transmission,
                    opt => opt.MapFrom(src => src.Transmission))
                .ForMember(
                    dest => dest.OwnerId,
                    opt => opt.MapFrom(src => src.OwnerId))
                .ForMember(
                    dest => dest.Owner,
                    opt => opt.MapFrom(src => src.Owner))
                .ForMember(
                    dest => dest.YearOfRelease,
                    opt => opt.MapFrom(src => src.YearOfRelease))
                .ForMember(
                    dest => dest.EnginePower,
                    opt => opt.MapFrom(src => src.EnginePower))
                .ForMember(
                    dest => dest.Images,
                    opt => opt.MapFrom(src => src.Images))
                .ForMember(
                    dest => dest.Applications,
                    opt => opt.MapFrom(src => src.Applications));
            CreateMap<CreateCarDTO, Car>()
                .ForMember(
                    dest => dest.BrandId,
                    opt => opt.MapFrom(src => src.BrandId))
                .ForMember(
                    dest => dest.ModelId,
                    opt => opt.MapFrom(src => src.ModelId))
                .ForMember(
                    dest => dest.TransmissionId,
                    opt => opt.MapFrom(src => src.TransmissionId))
                .ForMember(
                    dest => dest.OwnerId,
                    opt => opt.MapFrom(src => src.OwnerId))
                .ForMember(
                    dest => dest.YearOfRelease,
                    opt => opt.MapFrom(src => src.YearOfRelease))
                .ForMember(
                    dest => dest.EnginePower,
                    opt => opt.MapFrom(src => src.EnginePower));
            CreateMap<Car, CarTableDTO>();
        }
    }
}
