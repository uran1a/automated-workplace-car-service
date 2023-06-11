using AutomatedWorkplaceCarService.Models;
using AutomatedWorkplaceCarService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.Pages.Users.Employees.Admin
{
    public class ClientsModel : PageModel
    {
        private readonly IClientRepository _clientRepository;
        public ClientsModel(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public IEnumerable<Client> Clients { get; set; }
        public void OnGet()
        {
            Clients = _clientRepository.GetAllClients();
        }
    }
}
