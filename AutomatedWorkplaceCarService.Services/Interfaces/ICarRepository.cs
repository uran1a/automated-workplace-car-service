using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface ICarRepository
    {
        Car Add(Car car);
        List<Car> GetAllCars();
        Task<Car> GetCarAsync(int id);
    }
}
