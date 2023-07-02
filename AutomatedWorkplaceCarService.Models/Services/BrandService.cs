using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs.Brand;
using AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.Interfaces;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;

        public BrandService(IUnitOfWork uow, IMapper mapper)
        {
            _db = uow;
            _mapper = mapper;
        }
        public async Task<List<BrandDTO>> GetAllBrandsAsync()
        {
            return _mapper.Map<List<BrandDTO>>(await _db.Brands.GetAllBrandsAsync());
        }
    }
}
