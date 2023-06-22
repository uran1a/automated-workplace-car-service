using AutomatedWorkplaceCarService.DAL.Entities;

namespace AutomatedWorkplaceCarService.DAL.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Brand> GetAllBrands();
        IEnumerable<Transmission> GetAllTransmissions();
        IEnumerable<Model> GetModels(int brandId);
    }
}
