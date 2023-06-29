using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
{
    public class EmployeesModel : PageModel
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public EmployeesModel(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }
        public ICollection<EmployeeModel> Employees { get; set; } 
        public ICollection<PostModel> Posts { get; set; } 
        public async void OnGet()
        {
            Employees = _mapper.Map<List<EmployeeModel>>(_adminService.GetAllEmployeesAsync(int.Parse(User.Identity.Name)).Result);
        }
    }
}
