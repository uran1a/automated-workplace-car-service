using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.DTOs.Brand;
using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using AutomatedWorkplaceCarService.BLL.DTOs.Image;
using AutomatedWorkplaceCarService.BLL.DTOs.Model;
using AutomatedWorkplaceCarService.BLL.DTOs.Transmission;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.WEB.Pages.Employees.Admin
{
    public class CreateCarModel : PageModel
    {
        private readonly ICarService _carService;
        private readonly IBrandService _brandService;
        private readonly ITransmissionService _transmissionService;
        private readonly IImageService _imageService;
        private readonly IClientService _clientService;

        public CreateCarModel(ICarService carService, IBrandService brandService, 
            ITransmissionService transmissionService, IImageService imageService, IClientService clientService)
        {
            _carService = carService;
            _brandService = brandService;
            _transmissionService = transmissionService;
            _imageService = imageService;
            _clientService = clientService;
        }
        [BindProperty]
        public CreateCarDTO Car { get; set; }
        public List<ClientDTO> Clients { get; set; }
        public List<BrandDTO> Brands { get; set; }
        public List<ModelDTO> Models { get; set; }
        public List<TransmissionDTO> Transmissions { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Clients = await _clientService.GetAllClientsAsync();
            Brands = await _brandService.GetAllBrandsAsync();
            Models = new List<ModelDTO>();
            Transmissions = await _transmissionService.GetAllTransmissionsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPost(IFormFile? imageAuto)
        {
            if (ModelState.IsValid)
            {
                if (imageAuto != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(imageAuto.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)imageAuto.Length);
                    }
                    var imageDTO = new CreateImageDTO()
                    {
                        FileName = imageAuto.FileName,
                        ContentType = imageAuto.ContentType,
                        Content = imageData
                    };
                    var newCarDTO = await _carService.Add(Car);
                    await _imageService.AddImages(new List<CreateImageDTO>() { imageDTO }, newCarDTO.Id);

                    TempData["SuccessMessage"] = $"Добавление автомобиля {newCarDTO.Brand.Name} {newCarDTO.Model.Name} прошло успешно!";
                    return RedirectToPage("/Employees/Admin/Cars");
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
            Clients = await _clientService.GetAllClientsAsync();
            Brands = await _brandService.GetAllBrandsAsync();
            Transmissions = await _transmissionService.GetAllTransmissionsAsync();
            return Page();
        }
    }
}
