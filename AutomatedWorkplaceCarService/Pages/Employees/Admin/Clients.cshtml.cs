using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Users.Employees.Admin
{
    public class ClientsModel : PageModel
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public ClientsModel(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }
        public ICollection<ClientViewModel> Clients { get; set; }
        public void OnGet()
        {
            var clientDTOs = _clientService.GetAllClientsAsync().Result;
            Clients = _mapper.Map<List<ClientViewModel>>(clientDTOs);
        }
    }
}
