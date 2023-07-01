using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
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
        private readonly IMapper _mapper;
        public EvaluationApplicationModel(IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
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
                var evaluationApplicationDTO = _mapper.Map<EvaluationApplicationDTO>(EvaluationApplication);
                await _applicationService.AddEvaluationApplicationAsync(evaluationApplicationDTO);
                TempData["SuccessMessage"] = $"Заявка отправлена на подтверждение клиенту!";
                return RedirectToPage("/Employees/Master/Applications");
            }
            Application = await _applicationService.GetApplication(EvaluationApplication.Id);
            return Page();
        }
    }
}
