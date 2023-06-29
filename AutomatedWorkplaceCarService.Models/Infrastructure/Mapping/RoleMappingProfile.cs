using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
        }
    }
}
