using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<Post, PostDTO>().ReverseMap();
        }
    }
}
