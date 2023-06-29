using AutomatedWorkplaceCarService.BLL.DTOs.Car;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface ICarService
    {
        Task<CarDTO> Add(CreateCarDTO carDTO);
        Task<List<CarDTO>> GetAllCarsAsync();
        Task<List<CarTableDTO>> GetCarsAsync(int ownerId);
        Task<CarDTO> GetCarAsync(int id);

    }
}
