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
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public EditClientModel(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }
        [BindProperty]
        public ClientViewModel Client { get; set; }
        public async Task<IActionResult> OnGet(int? id)
        {
            if (id.HasValue)
            {
                Client = _mapper.Map<ClientViewModel>(await _adminService.GetClientAsync(id.Value));
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
                    Client = _mapper.Map<ClientViewModel>(await _adminService.UpdateClientAsync(clientDTO));
                    if (Client == null)
                        return RedirectToPage("/Error");
                    TempData["SuccessMessage"] = $"Обновление сотрудника {Client.Name} прошло успешно!";
                }
                else
                {
                    var clientDTO = _mapper.Map<ClientDTO>(Client);
                    Client = _mapper.Map<ClientViewModel>(await _adminService.AddClientAsync(clientDTO));
                    if (Client == null)
                        return RedirectToPage("/Error");
                    TempData["SuccessMessage"] = $"Создание сотрудника {Client.Name} прошло успешно!";
                }
                return RedirectToPage("/Employees/Admin/Clients");
            }
            return Page();
        }
    }
}
