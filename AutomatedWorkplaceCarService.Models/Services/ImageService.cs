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
        public async Task AddImages(List<CreateImageDTO> images, int id, bool isCar)
        {
            foreach(var imageDTO in images)
            {
                if (isCar)
                {
                    imageDTO.CarId = id;
                    imageDTO.ApplicationId = null;
                }
                else
                {
                    imageDTO.CarId = null;
                    imageDTO.ApplicationId = id;
                }
                _db.Images.Add(Mapping.Mapper.Map<Image>(imageDTO));
                await _db.SaveAsync();  
            }
        }
    }
}
