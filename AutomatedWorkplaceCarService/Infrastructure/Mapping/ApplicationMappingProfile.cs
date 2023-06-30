using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.WEB.ViewModels;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Mapping
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<CreateApplicationViewModel, ApplicationDTO>();
        }
    }
}
