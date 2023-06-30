using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class ServiceService : IServiceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ServiceService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ServiceDTO>> GetAvailableServices()
        {
            var employees = await _context.Employees
                .Include(e => e.Role)
                .Where(e => !e.Role.Name.Equals("admin"))
                .Include(e => e.Post).ToListAsync();
            var postIds = employees
                .Select(e => e.PostId)
                .Distinct().ToList();
            var availableServiceIds = _context.Specializations
                .Where(s => postIds.Contains(s.PostId))
                .Select(s => s.ServiceId).ToList();
            var availableServices = _context.Services
               .Where(s => availableServiceIds.Contains(s.Id)).ToList();
            return _mapper.Map<List<ServiceDTO>>(availableServices);
        }
    }
}
