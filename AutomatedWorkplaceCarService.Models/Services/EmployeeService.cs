using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
		private readonly IRoleService _roleService;

		public EmployeeService(ApplicationDbContext context, IMapper mapper, 
            IRoleService roleService)
        {
            _context = context;
            _mapper = mapper;
            _roleService = roleService;
        }

		public async Task<EmployeeDTO?> AddEmployeeAsync(EmployeeDTO employeeDTO)
		{
            var employee = _mapper.Map<Employee>(employeeDTO);
            var role = await _roleService.GetRoleAsync("employee");
            if (role == null) return null;
            employee.RoleId = role.Id;
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employeeDTO;
        }

		public async Task<EmployeeDTO?> DeleteEmployeeAsync(int id)
		{
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return null;
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return _mapper.Map<EmployeeDTO>(employee);
        }

		public async Task<List<EmployeeDTO>> GetAllEmployeesAsync(int id)
		{
            var employees = await _context.Employees
                .Include(e => e.Post)
                .Include(e => e.Applications).ToListAsync();
            if (employees == null) employees = new List<Employee>();
            else employees = employees.Where(e => e.Id != id).ToList();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

		public async Task<EmployeeDTO?> GetEmployeeAsync(int id)
		{
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null) return null;
            return _mapper.Map<EmployeeDTO>(employee);
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

		public async Task<EmployeeDTO> UpdateEmployeeAsync(EmployeeDTO employeeDTO)
		{
            var employee = _mapper.Map<Employee>(employeeDTO);
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employeeDTO;
        }
	}
}
