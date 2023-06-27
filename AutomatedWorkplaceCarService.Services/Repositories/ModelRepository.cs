using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Interfaces;

namespace AutomatedWorkplaceCarService.DAL.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly ApplicationDbContext _context;
        public ModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
