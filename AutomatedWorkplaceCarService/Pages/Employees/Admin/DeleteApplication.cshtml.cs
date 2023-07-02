using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutoMapper;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
{
    public class DeleteApplicationModel : PageModel
    {
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public DeleteApplicationModel(IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }
        [BindProperty]
        public ApplicationDTO Application { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Application = await _applicationService.GetApplication(id);
            if (Application == null)
                return RedirectToPage("/NotFound");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _applicationService.DeleteAsync(id);
            return RedirectToPage("/Employees/Admin/Applications");
        }
    }
}
