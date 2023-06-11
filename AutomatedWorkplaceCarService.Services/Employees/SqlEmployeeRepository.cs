using AutomatedWorkplaceCarService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.Services
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public SqlEmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Employee> GetAllEmployees(int id)
        {
            return _context.Employees.Where(e => e.Id != id).ToList();    
        }

		public IEnumerable<Post> GetAllPosts(string post)
		{
            return _context.Posts.Where(p => !p.Name.Contains(post)).ToList();
		}

		public Employee GetEmployee(int id)
		{
            return _context.Employees
                .Include(e => e.Post).FirstOrDefault(e => e.Id == id);
        }
	}
}
