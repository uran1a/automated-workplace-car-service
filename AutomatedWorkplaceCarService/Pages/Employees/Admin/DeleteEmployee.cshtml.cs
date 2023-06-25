using AutoMapper;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
{
    public class DeleteEmployeeModel : PageModel
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public DeleteEmployeeModel(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }
        [BindProperty]
        public EmployeeModel Employee { get; set; } 
        public async Task<IActionResult> OnGet(int id)
        {
            Employee = _mapper.Map<EmployeeModel>(await _adminService.GetEmployeeAsync(id));
            if(Employee == null)
                return RedirectToPage("/NotFound");
            return Page();  
        }
        public async Task<IActionResult> OnPost()
        {
            var deletedEmployee = _mapper.Map<EmployeeModel>(await _adminService.DeleteEmployeeAsync(Employee.Id));
            if (deletedEmployee == null)
                return RedirectToPage("/NotFound");
            return RedirectToPage("/Employees/Admin/Employees");
        }
    }
}
