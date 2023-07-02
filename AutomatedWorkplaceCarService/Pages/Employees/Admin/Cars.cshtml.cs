using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
{
    public class CarsModel : PageModel
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarsModel(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }
        public List<CarDTO> Cars { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Cars = await _carService.GetAllCarsAsync();
            return Page();
        }
    }
}
