using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
