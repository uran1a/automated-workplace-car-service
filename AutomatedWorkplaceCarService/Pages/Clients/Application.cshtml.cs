using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Clients
{
    public class ApplicationModel : PageModel
    {
        private readonly IApplicationService _applicationService;
        public ApplicationModel(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public ApplicationDTO Application { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Application = await _applicationService.GetApplication(id);
            Console.WriteLine(Application.StartWork.ToShortDateString());
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _applicationService.MakeApplicationConfirmed(id);
            TempData["SuccessMessage"] = $"Заявка подтверждена и мастер приступит к ее выполнению!";
            return RedirectToPage("/Clients/Applications");
        }
    }
}
