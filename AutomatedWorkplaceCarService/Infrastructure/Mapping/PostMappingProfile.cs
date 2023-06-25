using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.WEB.Models;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Mapping
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<PostModel, PostDTO>().ReverseMap();
        }
    }
}
