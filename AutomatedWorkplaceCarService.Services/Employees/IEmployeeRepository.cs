using AutomatedWorkplaceCarService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedWorkplaceCarService.Services
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees(int id);
        IEnumerable<Post> GetAllPosts(string post);
        Employee Update(Employee updatedEmployee);
        Employee Add(Employee newEmployee);
    }
}
