using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.WEB.Models;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.AutoMapperProfiles
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UserModel, UserDTO>();
            CreateMap<EmployeeModel, EmployeeDTO>();
            CreateMap<ClientModel, ClientDTO>();
        }
    }
}
