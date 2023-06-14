using AutomatedWorkplaceCarService.Models;
using AutomatedWorkplaceCarService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.Pages.Employees.Admin
{
    public class EditClientModel : PageModel
    {
        private readonly IClientRepository _clientRepository;
        public EditClientModel(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [BindProperty]
        public Client Client { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Client = _clientRepository.GetClient(id.Value);
                if (Client == null)
                    return RedirectToPage("/NotFound");
            }
            else
                Client = new Client();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Client.Id > 0)
                {
                    Client = _clientRepository.Update(Client);
                    if (Client == null)
                        return RedirectToPage("/NotFound");
                    TempData["SuccessMessage"] = $"Обновление сотрудника {Client.Name} прошло успешно!";
                }
                else
                {
                    Client = _clientRepository.Add(Client);
                    if (Client == null)
                        return RedirectToPage("/NotFound");
                    TempData["SuccessMessage"] = $"Создание сотрудника {Client.Name} прошло успешно!";
                }
                return RedirectToPage("/Employees/Admin/Clients");
            }
            return Page();
        }
    }
}
