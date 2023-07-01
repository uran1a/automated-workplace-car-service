using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.WEB.ViewModels;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Mapping
{
    public class EvaluationApplicationMappingProfile : Profile
    {
        public EvaluationApplicationMappingProfile()
        {
            CreateMap<EvaluationApplicationViewModel, EvaluationApplicationDTO>(); 
        }
    }
}
