using AutomatedWorkplaceCarService.BLL.DTOs.Brand;

namespace AutomatedWorkplaceCarService.BLL.Interfaces
{
    public interface IBrandService
    {
        Task<List<BrandDTO>> GetAllBrandsAsync();
    }
}
