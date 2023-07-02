using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Master
{
    public class ApplicationModel : PageModel
    {
        private readonly IApplicationService _applicationService;
        public ApplicationModel(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        [BindProperty]
        public CompleteApplicationViewModel CompleteApplication { get; set; }
        public ApplicationDTO Application { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Application = await _applicationService.GetApplication(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (ModelState.IsValid)
            {
                await _applicationService.CompleteApplication(id, CompleteApplication.WorkshopAddress);
                TempData["SuccessMessage"] = $"Работа выполненена, приступайте к следующей заявке!";
                return RedirectToPage("/Employees/Master/Applications");
            }
            Application = await _applicationService.GetApplication(id);
            return Page();
        }
    }
}
