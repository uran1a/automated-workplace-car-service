using AutoMapper;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
{
    public class DeleteClientModel : PageModel
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public DeleteClientModel(IAdminService adminservice, IMapper mapper)
        {
            _adminService = adminservice;
            _mapper = mapper;
        }
        [BindProperty]
        public ClientViewModel Client { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Client = _mapper.Map<ClientViewModel>(await _adminService.GetClientAsync(id));
            if (Client == null)
                return RedirectToPage("/NotFound");
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            await _adminService.DeleteClientAsync(Client.Id);
            return RedirectToPage("/Employees/Admin/Clients");
        }
    }
}
