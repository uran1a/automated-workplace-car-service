using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
{
    public class EditEmployeeModel : PageModel
    {

        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public EditEmployeeModel(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }
        [BindProperty]
        public Models.EditEmployeeModel Employee { get; set; }
        [BindProperty]
        public ICollection<PostModel> Posts { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id.HasValue)
                Employee = _mapper.Map<Models.EditEmployeeModel>(await _adminService.GetEmployeeAsync(id.Value));
            else
                Employee = new Models.EditEmployeeModel();
            var currentEmployee = await _adminService.GetEmployeeAsync(int.Parse(User.Identity.Name));
            if (currentEmployee == null)
                return RedirectToPage("/NotFound");
            Posts = _mapper.Map<ICollection<PostModel>>(await _adminService.GetAllPostsAsync(currentEmployee.Post.Id));
            if (Employee == null)
                return RedirectToPage("/NotFound");
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Employee.Id > 0)
                {
                    var employeeDTO = _mapper.Map<EmployeeDTO>(Employee);
                    Employee = _mapper.Map<Models.EditEmployeeModel>(await _adminService.UpdateEmployeeAsync(employeeDTO));
                    if (Employee == null)
                        return RedirectToPage("/NotFound");
                    TempData["SuccessMessage"] = $"Обновление сотрудника {Employee.Name} прошло успешно!";
                }
                else
                {
                    var employeeDTO = _mapper.Map<EmployeeDTO>(Employee);
                    Employee = _mapper.Map<Models.EditEmployeeModel>(await _adminService.AddEmployeeAsync(employeeDTO));
                    if (Employee == null)
                        return RedirectToPage("/NotFound");
                    TempData["SuccessMessage"] = $"Создание сотрудника {Employee.Name} прошло успешно!";
                }
                return RedirectToPage("/Employees/Admin/Employees");
            }
            var currentEmployee = await _adminService.GetEmployeeAsync(int.Parse(User.Identity.Name));
            if (currentEmployee == null)
                return RedirectToPage("/NotFound");
            Posts = _mapper.Map<ICollection<PostModel>>(await _adminService.GetAllPostsAsync(currentEmployee.Post.Id));
            return Page();
        }
    }
}
