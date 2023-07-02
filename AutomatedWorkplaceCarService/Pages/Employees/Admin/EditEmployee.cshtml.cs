using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
{
    public class EditEmployeeModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public EditEmployeeModel(IEmployeeService employeeService, IPostService postService, IMapper mapper)
        {
            _employeeService = employeeService;
            _postService = postService;
            _mapper = mapper;
        }
        [BindProperty]
        public EmployeeViewModel Employee { get; set; }
        [BindProperty]
        public ICollection<PostViewModel> Posts { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id.HasValue)
                Employee = _mapper.Map<EmployeeViewModel>(await _employeeService.GetEmployeeAsync(id.Value));
            else
                Employee = new EmployeeViewModel();
            var currentEmployee = await _employeeService.GetEmployeeAsync(int.Parse(User.Identity.Name));
            if (currentEmployee == null)
                return RedirectToPage("/NotFound");
            Posts = _mapper.Map<List<PostViewModel>>(await _postService.GetAllPostsAsync(currentEmployee.PostId));
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
                    Employee = _mapper.Map<EmployeeViewModel>(await _employeeService.UpdateEmployeeAsync(employeeDTO));
                    if (Employee == null)
                        return RedirectToPage("/NotFound");
                    TempData["SuccessMessage"] = $"Обновление сотрудника {Employee.Name} прошло успешно!";
                }
                else
                {
                    var employeeDTO = _mapper.Map<EmployeeDTO>(Employee);
                    Employee = _mapper.Map<EmployeeViewModel>(await _employeeService.AddEmployeeAsync(employeeDTO));
                    if (Employee == null)
                        return RedirectToPage("/NotFound");
                    TempData["SuccessMessage"] = $"Создание сотрудника {Employee.Name} прошло успешно!";
                }
                return RedirectToPage("/Employees/Admin/Employees");
            }
            var currentEmployee = await _employeeService.GetEmployeeAsync(int.Parse(User.Identity.Name));
            if (currentEmployee == null)
                return RedirectToPage("/NotFound");
            Posts = _mapper.Map<List<PostViewModel>>(await _postService.GetAllPostsAsync(currentEmployee.PostId));
            return Page();
        }
    }
}
