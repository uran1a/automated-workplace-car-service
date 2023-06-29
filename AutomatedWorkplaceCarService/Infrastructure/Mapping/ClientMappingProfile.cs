using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.WEB.Models;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Mapping
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<ClientDTO, ClientModel>()
                 .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(
                    dest => dest.Surname,
                    opt => opt.MapFrom(src => src.Surname))
                .ForMember(
                    dest => dest.Patronymic,
                    opt => opt.MapFrom(src => src.Patronymic))
                .ForMember(
                    dest => dest.Login,
                    opt => opt.MapFrom(src => src.Login))
                .ForMember(
                    dest => dest.Password,
                    opt => opt.MapFrom(src => src.Password))
                .ForMember(
                    dest => dest.RoleId,
                    opt => opt.MapFrom(src => src.RoleId))
                .ForMember(
                    dest => dest.MobilePhone,
                    opt => opt.MapFrom(src => src.MobilePhone));
        }
    }
}
