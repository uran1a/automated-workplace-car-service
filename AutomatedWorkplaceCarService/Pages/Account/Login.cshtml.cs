using AutoMapper;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.Models;
using AutomatedWorkplaceCarService.Services;
using AutomatedWorkplaceCarService.WEB.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AutomatedWorkplaceCarService.Pages.Account
{
    public class AuthenticationModel : PageModel
    {
        private readonly IAuthentificationService _authentificationService;
        private readonly IMapper _mapper;
        public AuthenticationModel(IAuthentificationService authentificationService, IMapper mapper)
        {
            _authentificationService = authentificationService;
            _mapper = mapper;
        }
        [BindProperty]
        public AuthenticationViewModel Authentication { get; set; }
        public void OnGet() {}
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userDTO = await _authentificationService.GetUserAsync(Authentication.Login, Authentication.Password);
                var user = _mapper.Map<UserViewModel>(userDTO);
                if (user != null)
                {
                    await Authenticate(user);
                    
                    var role = 
                    if()

                    switch (user.RoleId)
                    {
                        case Role.Client:
                            return RedirectToPage("/Clients/Applications");
                        case Role.Admin:
                            return RedirectToPage("/Employees/Admin/Clients");
                        default:
                            return RedirectToPage("/Error");
                    }
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return Page();
        }
        private async Task Authenticate(UserViewModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
    }
}
