using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutomatedWorkplaceCarService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;
        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Car Add(Car car)
        {
            var newCar = _context.Cars.Add(car);
            return newCar.Entity;
        }

        public async Task<List<Car>> GetAllCarsAsync()
        {
            return await _context.Cars
                .Include(c => c.Model)
                .Include(c => c.Brand)
                .Include(c => c.Transmission)
                .Include(c => c.Owner)
                .Include(c => c.Applications)
                .Include(c => c.Images).ToListAsync();
        }

        public Task<Car?> GetCarAsync(int id)
        {
            return _context.Cars
                .Include(c => c.Model)
                .Include(c => c.Brand)
                .Include(c => c.Transmission)
                .Include(c => c.Owner)
                .Include(c => c.Applications)
                .Include(c => c.Images).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
