using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
{
    public class DeleteEmployeeModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public DeleteEmployeeModel(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        [BindProperty]
        public EmployeeViewModel Employee { get; set; } 
        public async Task<IActionResult> OnGet(int id)
        {
            Employee = _mapper.Map<EmployeeViewModel>(await _employeeService.GetEmployeeAsync(id));
            if(Employee == null)
                return RedirectToPage("/NotFound");
            return Page();  
        }
        public async Task<IActionResult> OnPost()
        {
            var deletedEmployee = await _employeeService.DeleteEmployeeAsync(Employee.Id);
            if (deletedEmployee == null)
                return RedirectToPage("/NotFound");
            return RedirectToPage("/Employees/Admin/Employees");
        }
    }
}
