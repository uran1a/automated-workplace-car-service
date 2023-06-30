using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.WEB.ViewModels;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserViewModel, UserDTO>().ReverseMap();
        }
    }
}
