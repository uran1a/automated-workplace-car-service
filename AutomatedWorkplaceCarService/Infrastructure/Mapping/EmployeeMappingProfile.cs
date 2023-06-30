using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.WEB.ViewModels;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Mapping
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeDTO, EmployeeViewModel>()
                .ForMember(
                    dest => dest.PostId,
                    opt => opt.MapFrom(src => src.PostId))
                .ForMember(
                    dest => dest.PostName,
                    opt => opt.MapFrom(src => src.Post.Name));
            CreateMap<EmployeeViewModel, EmployeeDTO>();
        }
    }
}
