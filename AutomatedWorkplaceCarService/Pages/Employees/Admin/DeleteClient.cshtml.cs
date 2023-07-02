using AutoMapper;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
{
    public class DeleteClientModel : PageModel
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public DeleteClientModel(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }
        [BindProperty]
        public ClientViewModel Client { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            Client = _mapper.Map<ClientViewModel>(await _clientService.GetClientAsync(id));
            if (Client == null)
                return RedirectToPage("/NotFound");
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            await _clientService.DeleteClientAsync(Client.Id);
            return RedirectToPage("/Employees/Admin/Clients");
        }
    }
}
