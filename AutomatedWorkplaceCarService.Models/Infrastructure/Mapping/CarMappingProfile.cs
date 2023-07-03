using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutoMapper;

namespace AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<CreateCarDTO, Car>().ReverseMap();
            CreateMap<CreateCarDTO, CarDTO>().ReverseMap();
            CreateMap<Car, CarTableDTO>()
                .ForMember(
                    dest => dest.BrandName,
                    opt => opt.MapFrom(src => src.Brand.Name))
                .ForMember(
                    dest => dest.ModelName,
                    opt => opt.MapFrom(src => src.Model.Name))
                .ForMember(
                    dest => dest.TransmissionName,
                    opt => opt.MapFrom(src => src.Transmission.Name));
                
        }
    }
}
