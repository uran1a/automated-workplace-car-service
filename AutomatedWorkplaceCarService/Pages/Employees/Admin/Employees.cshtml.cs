using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
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
        public ICollection<EmployeeViewModel> Employees { get; set; } 
        public ICollection<PostViewModel> Posts { get; set; } 
        public async void OnGet()
        {
            Employees = _mapper.Map<List<EmployeeViewModel>>(_adminService.GetAllEmployeesAsync(int.Parse(User.Identity.Name)).Result);
        }
    }
}
