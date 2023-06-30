using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Users.Employees.Admin
{
    public class ClientsModel : PageModel
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;
        public ClientsModel(IAdminService adminservice, IMapper mapper)
        {
            _adminService = adminservice;
            _mapper = mapper;
        }
        public ICollection<ClientViewModel> Clients { get; set; }
        public void OnGet()
        {
            var clientDTOs = _adminService.GetAllClientsAsync().Result;
            Clients = _mapper.Map<List<ClientViewModel>>(clientDTOs);
        }
    }
}
