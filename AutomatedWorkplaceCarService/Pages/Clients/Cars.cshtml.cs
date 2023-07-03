using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.Pages.Clients
{
    public class CarsModel : PageModel
    {
        private readonly ICarService _carService;

        public CarsModel(ICarService carService)
        {
            _carService = carService;
        }
        [BindProperty]
        public List<CarDTO> Cars { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Cars = await _carService.SearchAsync(SearchTerm, int.Parse(User.Identity!.Name!));
            return Page();
        }
    }
}
