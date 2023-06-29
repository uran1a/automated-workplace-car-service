using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Clients
{
    public class CreateApplicationModel : PageModel
    {
        private readonly ICarService _carService;
        private readonly IServiceService _serviceService;
        public CreateApplicationModel(ICarService carService, IServiceService serviceService)
        {
            _carService = carService;
            _serviceService = serviceService;
        }
        [BindProperty]
        public ApplicationDTO Application { get; set; }
        [BindProperty]
        public List<CarTableDTO> Cars { get; set; }
        [BindProperty]
        public List<ServiceDTO> Services { get; set; }
        [BindProperty]
        public List<EmployeeDTO> Employees { get; set; }
        public void OnGet()  
        {
            Cars = _carService.GetCarsAsync(int.Parse(User.Identity.Name)).Result;
            Services = _serviceService.GetAvailableServices();
        }
        public void OnPost()
        {

        }
    } 
}
