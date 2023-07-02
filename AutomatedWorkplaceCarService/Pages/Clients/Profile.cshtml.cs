using AutoMapper;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Clients
{
    public class ProfileModel : PageModel
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ProfileModel(IClientService clientService, IMapper mapper)
		{
            _clientService = clientService;
            _mapper = mapper;
		}
        [BindProperty]
        public ClientViewModel Client { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Client = _mapper.Map<ClientViewModel>(await _clientService.GetClientAsync(int.Parse(User!.Identity!.Name)));
            return Page();
        }
    }
}
