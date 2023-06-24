using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutomatedWorkplaceCarService.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AutomatedWorkplaceCarService.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddAsync(Employee newEmployee)
        {
            var employee = await _context.Employees.AddAsync(newEmployee);
            return employee.Entity;
        }

        public Employee Delete(int id)
        {
            var employeeToDelete = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employeeToDelete != null)
            {
                _context.Employees.Remove(employeeToDelete);
                _context.SaveChanges();
            }
            return employeeToDelete;
        }

        public Employee Delete(Employee employeeToDelete)
        {
            var employee = _context.Employees.Remove(employeeToDelete);
            return employee.Entity;
        }

        public IEnumerable<Employee> GetAllEmployees(int id)
        {
            return _context.Employees
                .Include(e => e.Post).Where(e => e.Id != id).ToList();
        }

        public async Task<ICollection<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<ICollection<Post>> GetAllPostsAsync(int postId)
        {
            return await _context.Posts.Where(p => p.Id != postId).ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            return await _context.Employees.Include(e => e.Post).FirstOrDefaultAsync(e => e.Id == id);
        }

        public Employee Update(Employee updatedEmployee)
        {
            _context.Employees.Update(updatedEmployee);
            _context.SaveChanges();
            return updatedEmployee;
        }
    }
}
