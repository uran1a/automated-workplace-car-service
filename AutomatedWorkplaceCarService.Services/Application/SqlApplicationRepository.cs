using AutomatedWorkplaceCarService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.Services
{
    public class SqlApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;
        public SqlApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Brand> GetAllBrands()
        {
            return _context.Brands.ToList();
        }
        public IEnumerable<Model> GetModels(int brandId)
        {
            return _context.Models.Where(m => m.BrandId == brandId);
        }
    }
}
