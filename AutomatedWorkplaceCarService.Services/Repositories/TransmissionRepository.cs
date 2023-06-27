using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutomatedWorkplaceCarService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.DAL.Repositories
{
    public class TransmissionRepository : ITransmissionRepository
    {
        private readonly ApplicationDbContext _context;
        public TransmissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Transmission>> GetAllTransmissionsAsync()
        {
            return await _context.Transmissions.ToListAsync();
        }
    }
}
