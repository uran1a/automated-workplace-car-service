using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface ICarRepository
    {
        Car Add(Car car);
        Task<List<Car>> GetAllCarsAsync();
        Task<List<Car>> GetCarsAsync(int ownerId);
        Task<Car?> GetCarAsync(int id);
    }
}
