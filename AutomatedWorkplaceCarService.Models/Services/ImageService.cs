using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs.Image;
using AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutomatedWorkplaceCarService.DAL.Interfaces;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public ImageService(IUnitOfWork uow, IMapper mapper)
        {
            _db = uow;
            _mapper = mapper;
        }
        public async Task AddImages(List<CreateImageDTO> images, int id)
        {
            foreach(var imageDTO in images)
            {
                imageDTO.CarId = id;
                _db.Images.Add(_mapper.Map<Image>(imageDTO));
                await _db.SaveAsync();  
            }
        }
    }
}
