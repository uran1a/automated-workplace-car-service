using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs.Model;
using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<Model, ModelDTO>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => src.Id))
                 .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => src.Name))
                 .ForMember(
                    dest => dest.BrandId,
                    opt => opt.MapFrom(src => src.BrandId));
        }
    }
}
