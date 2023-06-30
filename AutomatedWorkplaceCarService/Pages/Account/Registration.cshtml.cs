using AutoMapper;
using AutomatedWorkplaceCarService.BLL.DTOs;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;


namespace AutomatedWorkplaceCarService.WEB.Pages.Account
{
    public class RegistrationModel : PageModel
    {
        private readonly IAuthentificationService _authentificationService;
        private readonly IMapper _mapper;
        public RegistrationModel(IAuthentificationService authentificationService, IMapper mapper)
        {
            _authentificationService = authentificationService;
            _mapper = mapper;
        }
        [BindProperty]
        public ClientViewModel Client { get; set; }
        public void OnGet(){}
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                if (Client != null)
                {
                    var user = _mapper.Map<UserViewModel>(await _authentificationService.GetUserAsync(Client.Login));
                    if (user == null)
                    {
                        var clientDTO = _mapper.Map<ClientDTO>(Client);
                        var newClient = await _authentificationService.AddClientAsync(clientDTO);
                        if(newClient == null)
                            return RedirectToPage("/Error");
                        await Authenticate(_mapper.Map<ClientViewModel>(newClient));
                        return RedirectToPage("/Clients/Applications");
                    }
                    else
                    {
                        ModelState.AddModelError("", "ѕользователь с таким логин уже существует");
                    }
                }
            }
            return Page();
        }
        private async Task Authenticate(ClientViewModel client)
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
