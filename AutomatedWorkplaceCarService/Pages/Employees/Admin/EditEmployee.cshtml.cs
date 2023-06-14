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
        [BindProperty]
        public Employee Employee { get; set; }
        [BindProperty]
        public IEnumerable<Post> Posts { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
                Employee = _employeeRepository.GetEmployee(id.Value);
            else
                Employee = new Employee();
            var currentEmployee = _employeeRepository.GetEmployee(int.Parse(User.Identity.Name));
            Posts = _employeeRepository.GetAllPosts(currentEmployee.Post.Name);
            if (Employee == null)
                return RedirectToPage("/NotFound");
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if(Employee.Id > 0)
                {
                    Employee = _employeeRepository.Update(Employee);
                    if (Employee == null)
                        return RedirectToPage("/NotFound");
                    TempData["SuccessMessage"] = $"Обновление сотрудника {Employee.Name} прошло успешно!";
                }
                else
                {
                    Employee = _employeeRepository.Add(Employee);
                    if (Employee == null)
                        return RedirectToPage("/NotFound");
                    TempData["SuccessMessage"] = $"Создание сотрудника {Employee.Name} прошло успешно!";
                }
                return RedirectToPage("/Employees/Admin/Employees");
            }
            var currentEmployee = _employeeRepository.GetEmployee(int.Parse(User.Identity.Name));
            Posts = _employeeRepository.GetAllPosts(currentEmployee.Post.Name);
            return Page();
        }
    }
}
