using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.WEB.Models;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Mapping
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeDTO, EmployeeModel>()
                .ForMember(
                    dest => dest.PostId,
                    opt => opt.MapFrom(src => src.PostId))
                .ForMember(
                    dest => dest.PostName,
                    opt => opt.MapFrom(src => src.Post.Name));
            CreateMap<EmployeeModel, EmployeeDTO>();
        }
    }
}
