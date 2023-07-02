using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Master
{
    public class ProfileModel : PageModel
    {
        private readonly IEmployeeService _employeeService;
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public ProfileModel(IEmployeeService employeeService, IPostService postService, IMapper mapper)
        {
            _employeeService = employeeService;
            _postService = postService;
            _mapper = mapper;
        }
        [BindProperty]
        public EmployeeViewModel Employee { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            var employee = await _employeeService.GetEmployeeAsync(int.Parse(User.Identity!.Name!));
            if(employee == null) return RedirectToPage("/Error");
            Employee = _mapper.Map<EmployeeViewModel>(employee);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var employee = await _employeeService.UpdateEmployeeAsync(_mapper.Map<EmployeeDTO>(Employee));

                TempData["SuccessMessage"] = $"{employee.Name} ваши персональные данные успешно обновлены!";
                return RedirectToPage("/Employees/Master/Applications");
            }
            return Page();
        }
    }
}
