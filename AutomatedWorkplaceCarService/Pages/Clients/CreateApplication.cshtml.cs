using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.DTOs.Application;
using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Clients
{
    public class CreateApplicationModel : PageModel
    {
        private readonly ICarService _carService;
        private readonly IServiceService _serviceService;
        private readonly IEmployeeService _employeeService;
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;
        public CreateApplicationModel(ICarService carService, IServiceService serviceService, 
            IEmployeeService employeeService, IApplicationService applicationService, IMapper mapper)
        {
            _carService = carService;
            _serviceService = serviceService;
            _employeeService = employeeService;
            _applicationService = applicationService;
            _mapper = mapper;
        }
        [BindProperty]
        public CreateApplicationViewModel Application { get; set; }
        [BindProperty]
        public List<CarTableDTO> Cars { get; set; }
        [BindProperty]
        public List<ServiceDTO> Services { get; set; }
        [BindProperty]
        public List<EmployeeDTO> Employees { get; set; }
        public async void OnGet()  
        {
            Cars = _carService.GetCarsAsync(int.Parse(User.Identity.Name)).Result;
            Services = _serviceService.GetAvailableServices().Result;
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                Application.ClientId = int.Parse(User.Identity.Name);
                Application.StageId = 1;
                var applicationDTO = _mapper.Map<ApplicationDTO>(Application);
                await _applicationService.AddAsync(applicationDTO);

                TempData["SuccessMessage"] = $"Заявка отправлена мастеру на оценивание. Ожидайте, изменение статуса заявки.";
                return RedirectToPage("/Clients/Applications");
            }
            if (Application.ServiceId > 0)
            {
                Employees = _employeeService.GetEmployeesAsync(Application.ServiceId).Result;
            }
            Cars = _carService.GetCarsAsync(int.Parse(User.Identity.Name)).Result;
            Services = _serviceService.GetAvailableServices().Result;
            return Page();
        }
    } 
}
