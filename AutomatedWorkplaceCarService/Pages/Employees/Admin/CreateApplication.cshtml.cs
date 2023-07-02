using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
{
    public class EditApplicationModel : PageModel
    {
        private readonly ICarService _carService;
        private readonly IClientService _clientService;
        private readonly IServiceService _serviceService;
        private readonly IEmployeeService _employeeService;
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;
        public EditApplicationModel(ICarService carService, IServiceService serviceService,
            IEmployeeService employeeService, IApplicationService applicationService, IClientService clientService,
            IMapper mapper)
        {
            _carService = carService;
            _clientService = clientService;
            _serviceService = serviceService;
            _employeeService = employeeService;
            _applicationService = applicationService;
            _mapper = mapper;
        }
        [BindProperty]
        public CreateApplicationViewModel Application { get; set; }
        public List<ClientDTO> Clients { get; set; }
        public List<CarTableDTO> Cars { get; set; }
        public List<ServiceDTO> Services { get; set; }
        public List<EmployeeDTO> Employees { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Clients = await _clientService.GetAllClientsAsync();
            Services = await _serviceService.GetAvailableServices();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            if(Application.ClientId > 0)
            {
                if (ModelState.IsValid)
                {
                    Application.StageId = 1;
                    var applicationDTO = _mapper.Map<ApplicationDTO>(Application);
                    await _applicationService.AddAsync(applicationDTO);

                    TempData["SuccessMessage"] = $"Заявка создана!";
                    return RedirectToPage("/Employees/Admin/Applications");
                }
                if (Application.ServiceId > 0)
                {
                    Employees = _employeeService.GetEmployeesAsync(Application.ServiceId).Result;
                }
                Cars = await _carService.GetCarsAsync(Application.ClientId);
            }
            else
            {
                ModelState.AddModelError("", "Выберите клиента");
            }
            Clients = await _clientService.GetAllClientsAsync();
            Services = await _serviceService.GetAvailableServices();
            return Page();
        }
    }
}
