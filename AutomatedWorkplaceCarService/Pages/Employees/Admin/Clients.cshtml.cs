using AutoMapper;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.Models;
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
        public ICollection<ClientModel> Clients { get; set; }
        public async void OnGet()
        {
            Clients = _mapper.Map<ICollection<ClientModel>>(await _adminService.GetAllClientsAsync());
        }
    }
}
