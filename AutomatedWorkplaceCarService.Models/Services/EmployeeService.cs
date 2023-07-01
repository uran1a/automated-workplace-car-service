using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public EmployeeService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<EmployeeDTO>> GetEmployeesAsync(int serviceId)
        {
            var postIds = await _context.Specializations
                .Where(s => s.ServiceId == serviceId)
                .Select(s => s.PostId).ToListAsync();
            var employees = await _context.Employees
                .Include(e => e.Post)
                .Where(e => e.PostId != null)
                .Where(e => postIds.Contains((int)e.PostId!)).ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }
    }
}
