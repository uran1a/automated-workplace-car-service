using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Master
{
    public class EvaluationApplicationModel : PageModel
    {
        private readonly IApplicationService _applicationService;
        public EvaluationApplicationModel(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        public ApplicationDTO Application { get; set; }
        [BindProperty]
        public EvaluationApplicationViewModel EvaluationApplication { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Application = await _applicationService.GetApplication(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {

                return Page();
            }
            Application = await _applicationService.GetApplication(EvaluationApplication.Id);
            return Page();
        }
    }
}
