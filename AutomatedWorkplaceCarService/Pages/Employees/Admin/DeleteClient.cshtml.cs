using AutomatedWorkplaceCarService.Models;
using AutomatedWorkplaceCarService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.Pages.Employees.Admin
{
    public class DeleteClientModel : PageModel
    {
        private readonly IClientRepository _clientRepository;
        public DeleteClientModel(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [BindProperty]
        public Client Client { get; set; }
        public IActionResult OnGet(int id)
        {
            Client = _clientRepository.GetClient(id);
            if (Client == null)
                return RedirectToPage("/NotFound");
            return Page();
        }
        public IActionResult OnPost()
        {
            Client deletedClient = _clientRepository.Delete(Client.Id);
            if (deletedClient == null)
                return RedirectToPage("/NotFound");
            return RedirectToPage("/Employees/Admin/Clients");
        }
    }
}
