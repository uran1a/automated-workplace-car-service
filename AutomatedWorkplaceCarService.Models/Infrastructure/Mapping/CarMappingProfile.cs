using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutoMapper;

namespace AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            CreateMap<Car, CarDTO>();
               /* .ForMember(
                    dest => dest.Id
                );*/
        }
    }
}
