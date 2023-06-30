using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping
{
    public class StageMappingProfile : Profile
    {
        public StageMappingProfile()
        {
            CreateMap<Stage, StageDTO>();
        }
    }
}
