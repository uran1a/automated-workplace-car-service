using AutomatedWorkplaceCarService.Models;
using AutomatedWorkplaceCarService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutomatedWorkplaceCarService.Pages.Clients
{
    public class CreateApplicationModel : PageModel
    {
        private readonly IApplicationRepository _applicationRepository;
        public CreateApplicationModel(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        [BindProperty]
        public Car Car { get; set; }
        [BindProperty]
        public IEnumerable<Brand> Brands { get; set; }
        [BindProperty]
        public IEnumerable<Model> Models { get; set; }
        public void OnGet()
        {
            Brands = _applicationRepository.GetAllBrands();
            Models = _applicationRepository.GetModels(1);
        }
        public void OnPost()
        {

        }
        public void OnPostSelectAuto()
        {

        }
    }
}
