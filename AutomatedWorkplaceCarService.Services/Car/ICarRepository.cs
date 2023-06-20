using AutomatedWorkplaceCarService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.Services
{
    public interface ICarRepository
    {
        IEnumerable<Brand> GetAllBrands();
        IEnumerable<Transmission> GetAllTransmissions();
        IEnumerable<Model> GetModels(int brandId);
    }
}
