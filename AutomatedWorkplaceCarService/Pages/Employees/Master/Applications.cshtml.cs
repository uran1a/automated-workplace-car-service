using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Master
{
    public class ApplicationsModel : PageModel
    {
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public ApplicationsModel(IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }
        [BindProperty]
        public List<ApplicationCardDTO> PendingApplications { get; set; }
        [BindProperty]
        public List<ApplicationCardDTO> ActiveApplications { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            PendingApplications = await _applicationService.GetApplications(int.Parse(User.Identity!.Name!), 1);
            ActiveApplications = await _applicationService.GetApplications(int.Parse(User.Identity!.Name!), 2);
            return Page();
        }
    }
}
