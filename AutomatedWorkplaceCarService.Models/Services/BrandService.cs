using AutomatedWorkplaceCarService.BLL.DTOs.Brand;
using AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.Interfaces;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _db;
        public BrandService(IUnitOfWork uow)
        {
            _db = uow;
        }
        public async Task<List<BrandDTO>> GetAllBrandsAsync()
        {
            return Mapping.Mapper.Map<List<BrandDTO>>(await _db.Brands.GetAllBrandsAsync());
        }
    }
}
