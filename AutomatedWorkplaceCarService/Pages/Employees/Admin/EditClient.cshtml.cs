using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
{
    public class EditClientModel : PageModel
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public EditClientModel(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }
        [BindProperty]
        public ClientViewModel Client { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id.HasValue)
            {
                Client = _mapper.Map<ClientViewModel>(await _clientService.GetClientAsync(id.Value));
                if (Client == null)
                    return RedirectToPage("/Error");
            }
            else
                Client = new ClientViewModel();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Client.Id > 0)
                {
                    var clientDTO = _mapper.Map<ClientDTO>(Client);
                    Client = _mapper.Map<ClientViewModel>(await _clientService.UpdateClientAsync(clientDTO));
                    if (Client == null)
                        return RedirectToPage("/Error");
                    TempData["SuccessMessage"] = $"���������� ���������� {Client.Name} ������ �������!";
                }
                else
                {
                    var clientDTO = _mapper.Map<ClientDTO>(Client);
                    Client = _mapper.Map<ClientViewModel>(await _clientService.AddClientAsync(clientDTO));
                    if (Client == null)
                        return RedirectToPage("/Error");
                    TempData["SuccessMessage"] = $"�������� ���������� {Client.Name} ������ �������!";
                }
                return RedirectToPage("/Employees/Admin/Clients");
            }
            return Page();
        }
    }
}
