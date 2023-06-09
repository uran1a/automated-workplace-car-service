using AutomatedWorkplaceCarService.Models;
using AutomatedWorkplaceCarService.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;


namespace AutomatedWorkplaceCarService.Pages.Account
{
    public class RegistrationModel : PageModel
    {
        private readonly IClientRepository _clientRepository;
        public RegistrationModel(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        [BindProperty]
        public Client Client { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Client != null)
                {
                    Client? client = _clientRepository.GetClientByLogin(Client.Login);
                    if (client == null)
                    {
                        var newClient = _clientRepository.Add(Client);
                        await Authenticate(newClient);
                        return RedirectToPage("/Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "ѕользователь с таким логин уже существует");
                    }
                }
            }
            return Page();
        }
        private async Task Authenticate(Client client)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, client.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
