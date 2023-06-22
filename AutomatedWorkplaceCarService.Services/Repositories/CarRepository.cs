using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Interfaces;

namespace AutomatedWorkplaceCarService.DAL.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;
        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Brand> GetAllBrands()
        {
            return _context.Brands.ToList();
        }

        public IEnumerable<Transmission> GetAllTransmissions()
        {
            return _context.Transmissions.ToList();
        }

        public IEnumerable<Model> GetModels(int brandId)
        {
            return _context.Models.Where(m => m.BrandId == brandId);
        }
    }
}
