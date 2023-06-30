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
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public DeleteEmployeeModel(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }
        [BindProperty]
        public EmployeeViewModel Employee { get; set; } 
        public async Task<IActionResult> OnGet(int id)
        {
            Employee = _mapper.Map<EmployeeViewModel>(await _adminService.GetEmployeeAsync(id));
            if(Employee == null)
                return RedirectToPage("/NotFound");
            return Page();  
        }
        public async Task<IActionResult> OnPost()
        {
            var deletedEmployee = await _adminService.DeleteEmployeeAsync(Employee.Id);
            if (deletedEmployee == null)
                return RedirectToPage("/NotFound");
            return RedirectToPage("/Employees/Admin/Employees");
        }
    }
}
