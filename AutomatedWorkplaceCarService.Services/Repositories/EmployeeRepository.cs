﻿using AutomatedWorkplaceCarService.DAL.EF;
using AutomatedWorkplaceCarService.DAL.Entities;
using AutomatedWorkplaceCarService.DAL.Interfaces;

namespace AutomatedWorkplaceCarService.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Employee Add(Employee newEmployee)
        {
            newEmployee.Role = Role.Employee;
            _context.Employees.Add(newEmployee);
            _context.SaveChanges();
            return newEmployee;
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

        public IEnumerable<Employee> GetAllEmployees(int id)
        {
            return _context.Employees
                .Include(e => e.Post).Where(e => e.Id != id).ToList();
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

        public Employee Update(Employee updatedEmployee)
        {
            _context.Employees.Update(updatedEmployee);
            _context.SaveChanges();
            return updatedEmployee;
        }
    }
}