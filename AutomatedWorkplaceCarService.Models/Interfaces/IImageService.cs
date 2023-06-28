using AutomatedWorkplaceCarService.BLL.DTOs.Image;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface IImageService
    {
        Task AddImages(List<CreateImageDTO> images, int id, bool isCar);
    }
}
