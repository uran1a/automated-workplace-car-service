using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs.Image;
using AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutomatedWorkplaceCarService.DAL.Interfaces;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ImageService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task AddImages(List<CreateImageDTO> images, int id)
        {
            foreach(var imageDTO in images)
            {
                imageDTO.CarId = id;
                _context.Images.Add(_mapper.Map<Image>(imageDTO));
                await _context.SaveChangesAsync();  
            }
        }

        public async Task UpdateImage(ImageDTO imageDTO)
        {
            _context.Images.Update(_mapper.Map<Image>(imageDTO));
            await _context.SaveChangesAsync();
        }
    }
}
