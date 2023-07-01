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
        public ImageService(IUnitOfWork uow)
        {
            _db = uow;
        }
        public async Task AddImages(List<CreateImageDTO> images, int id)
        {
            foreach(var imageDTO in images)
            {
                imageDTO.CarId = id;
                _db.Images.Add(Mapping.Mapper.Map<Image>(imageDTO));
                await _db.SaveAsync();  
            }
        }
    }
}
