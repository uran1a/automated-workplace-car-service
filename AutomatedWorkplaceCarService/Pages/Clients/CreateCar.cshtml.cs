using AutomatedWorkplaceCarService.BLL.DTOs.Brand;
using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using AutomatedWorkplaceCarService.BLL.DTOs.Image;
using AutomatedWorkplaceCarService.BLL.DTOs.Model;
using AutomatedWorkplaceCarService.BLL.DTOs.Transmission;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Clients
{
    public class CreateCarModel : PageModel
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;
        private readonly ITransmissionService _transmissionService;
        public CreateCarModel(ICarService carService, IBrandService brandService, ITransmissionService transmissionService)
        {
            _carService = carService;
            _brandService = brandService;
            _transmissionService = transmissionService;
        }
        [BindProperty]
        public CreateCarDTO Car { get; set; }
        [BindProperty]
        public List<BrandDTO> Brands { get; set; }
        [BindProperty]
        public List<ModelDTO> Models { get; set; }
        [BindProperty]
        public List<TransmissionDTO> Transmissions { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Brands = await _brandService.GetAllBrandsAsync();
            Models = new List<ModelDTO>();
            Transmissions = await _transmissionService.GetAllTransmissionsAsync();
            return Page();
        }
        
        public async Task<IActionResult> OnPost(IFormFile? imageAuto)
        {
            if (ModelState.IsValid)
            {

                if(imageAuto != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(imageAuto.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)imageAuto.Length);
                    }
                    var image = new CreateImageDTO()
                    {
                        FileName = imageAuto.FileName,
                        ContentType = imageAuto.ContentType,
                        Content = imageData
                    };
                    //_carService
                    
                }
                else
                {
                    ModelState.AddModelError("", "Выберите фото автомобиля");
                }
            }
            if (Car.BrandId > 0)
            {
                Brands = await _brandService.GetAllBrandsAsync();
                var selectedBrand = Brands.FirstOrDefault(b => b.Id == Car.BrandId);
                if (selectedBrand == null)
                    return RedirectToPage("/NotFound");
                Models = selectedBrand.Models;
            }
            else
            {
                Models = new List<ModelDTO>();
            }
            Brands = await _brandService.GetAllBrandsAsync();
            Transmissions = await _transmissionService.GetAllTransmissionsAsync();
            return Page();
        }
    }
}  
