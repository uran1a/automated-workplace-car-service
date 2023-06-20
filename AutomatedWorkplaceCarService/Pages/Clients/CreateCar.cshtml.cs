using AutomatedWorkplaceCarService.Models;
using AutomatedWorkplaceCarService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.Pages.Clients
{
    public class CreateCarModel : PageModel
    {
        private readonly ICarRepository _carRepository;
        public CreateCarModel(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [BindProperty]
        public Car Car { get; set; }
        [BindProperty]
        public IEnumerable<Brand> Brands { get; set; }
        [BindProperty]
        public IEnumerable<Model> Models { get; set; }
        public IEnumerable<Transmission> Transmissions { get; set; }
        public void OnGet()
        {
            Brands = _carRepository.GetAllBrands();
            Transmissions = _carRepository.GetAllTransmissions();
        }
    }
}
