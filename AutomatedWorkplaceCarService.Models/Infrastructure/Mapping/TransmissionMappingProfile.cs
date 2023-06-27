using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs.Transmission;
using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping
{
    public class TransmissionMappingProfile : Profile
    {
        public TransmissionMappingProfile()
        {
            CreateMap<Transmission, TransmissionDTO>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                 .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name));
        }
    }
}
