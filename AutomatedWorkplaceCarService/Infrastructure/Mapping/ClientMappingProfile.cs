using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.WEB.ViewModels;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Mapping
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<ClientDTO, ClientViewModel>().ReverseMap();
        }
    }
}
