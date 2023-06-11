using AutomatedWorkplaceCarService.Models;
using AutomatedWorkplaceCarService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.Pages.Employees.Admin
{
    public class EditEmployeeModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EditEmployeeModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Employee Employee { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public void OnGet()
        {
            var currentEmployee = _employeeRepository.GetEmployee(int.Parse(User.Identity.Name));
            Posts = _employeeRepository.GetAllPosts(currentEmployee.Post.Name);
        }
    }
}
