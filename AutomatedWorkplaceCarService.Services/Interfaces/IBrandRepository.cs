using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAllBrandsAsync();
    }
}
