using AutomatedWorkplaceCarService.BLL.DTOs.Car;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface ICarService
    {
        Task<CarDTO> Add(CreateCarDTO carDTO);
        Task<List<CarDTO>> GetAllCarsAsync();
        Task<List<CarTableDTO>> GetCarsAsync(int ownerId);
        Task<List<CarDTO>> GetCars(int ownerId);
        Task<List<CarDTO>> SearchAsync(string searchTerm, int ownerId);
        Task<CarDTO> GetCarAsync(int id);
        Task DeleteAsync(int id);
        Task<CarDTO> UpdateAsync(CarDTO cardDTO);

    }
}
