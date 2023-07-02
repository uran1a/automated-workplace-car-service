using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
{
    public class EmployeesModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        public EmployeesModel(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        public ICollection<EmployeeViewModel> Employees { get; set; } 
        public ICollection<PostViewModel> Posts { get; set; } 
        public async Task<IActionResult> OnGetAsync()
        {
            var employeeDTOs = await _employeeService.GetAllEmployeesAsync(int.Parse(User.Identity.Name));
            Employees = _mapper.Map<List<EmployeeViewModel>>(employeeDTOs);
            return Page();
        }
    }
}
