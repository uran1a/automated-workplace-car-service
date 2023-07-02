using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Clients
{
    public class ApplicationModel : PageModel
    {
        private readonly IApplicationService _applicationService;
        private readonly IStageService _stageService;

        public ApplicationModel(IApplicationService applicationService, IStageService stageService)
        {
            _applicationService = applicationService;
            _stageService = stageService;
        }
        public List<StageDTO> Stages { get; set; }
        public ApplicationDTO Application { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Application = await _applicationService.GetApplication(id);
            Stages = await _stageService.GetAllStagesAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _applicationService.MakeApplicationConfirmed(id);
            TempData["SuccessMessage"] = $"«а€вка подтверждена и мастер приступит к ее выполнению!";
            return RedirectToPage("/Clients/Applications");
        }
        public async Task<IActionResult> OnPostViewedAsync(int id)
        {

            await _applicationService.DeleteAsync(id);
            TempData["SuccessMessage"] = $"—пасибо, что использовали наш сервис!";
            return RedirectToPage("/Clients/Applications");
        }
    }
}
