using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
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
        public List<ApplicationDTO> Applicatons { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Applicatons = await _applicationService.GetAllApplicationsAsync();
            return Page();
        }
    }
}
