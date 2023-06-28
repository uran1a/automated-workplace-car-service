using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface ICarRepository
    {
        Car Add(Car car);
        Task<List<Car>> GetAllCarsAsync();
        Task<Car?> GetCarAsync(int id);
    }
}
