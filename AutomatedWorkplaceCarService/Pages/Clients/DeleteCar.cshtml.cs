using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Clients
{
    public class DeleteCarModel : PageModel
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public DeleteCarModel(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }
        [BindProperty]
        public CarDTO Car { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Car = await _carService.GetCarAsync(id);
            if (Car == null)
                return RedirectToPage("/NotFound");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            await _carService.DeleteAsync(id);
            return RedirectToPage("/Clients/Cars");
        }
    }
}
