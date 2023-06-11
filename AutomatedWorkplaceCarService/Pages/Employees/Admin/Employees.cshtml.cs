using AutomatedWorkplaceCarService.Models;
using AutomatedWorkplaceCarService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.Pages.Employees.Admin
{
    public class EmployeesModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<Employee> Employees { get; set; } 
        public void OnGet()
        {
            Employees = _employeeRepository.GetAllEmployees(int.Parse(User.Identity.Name));
        }
    }
}
