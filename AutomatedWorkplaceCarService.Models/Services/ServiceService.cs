using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class ServiceService : IServiceService
    {
        ApplicationDbContext _context;
        public ServiceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ServiceDTO> GetAvailableServices()
        {
            var employees = _context.Employees
                .Include(e => e.Role)
                .Where(e => !e.Role.Name.Equals("admin"))
                .Include(e => e.Post).ToList();
            var postIds = employees
                .Select(e => e.PostId)
                .Distinct().ToList();
            var availableServices = _context.Specializations
                .Where(s => postIds.Contains(s.PostId))
                .Select(s => s.ServiceId).ToList();

            return new List<ServiceDTO>();
        }
    }
}
