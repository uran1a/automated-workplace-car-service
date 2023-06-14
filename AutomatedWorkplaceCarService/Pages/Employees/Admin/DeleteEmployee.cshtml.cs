using AutomatedWorkplaceCarService.Models;
using AutomatedWorkplaceCarService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.Pages.Employees.Admin
{
    public class DeleteEmployeeModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        public DeleteEmployeeModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [BindProperty]
        public Employee Employee { get; set; } 
        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);
            if(Employee == null)
                return RedirectToPage("/NotFound");
            return Page();
        }
        public IActionResult OnPost()
        {
            Employee deletedEmployee = _employeeRepository.Delete(Employee.Id);
            if (deletedEmployee == null)
                return RedirectToPage("/NotFound");
            return RedirectToPage("/Employees/Admin/Employees");
        }
    }
}
