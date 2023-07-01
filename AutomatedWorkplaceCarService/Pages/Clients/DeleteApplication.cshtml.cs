using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Clients
{
    public class DeleteApplicationModel : PageModel
    {
        private readonly IApplicationService _applicationService;
        public DeleteApplicationModel(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        [BindProperty]
        public ApplicationDTO Application { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Application = await _applicationService.GetApplication(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _applicationService.DeleteAsync(id);
            return RedirectToPage("/Clients/Applications");
        }
    }
}
