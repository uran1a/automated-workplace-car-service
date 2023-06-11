using AutomatedWorkplaceCarService.Models;
using AutomatedWorkplaceCarService.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AutomatedWorkplaceCarService.Pages.Account
{
    public class AuthenticationModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [BindProperty]
        public Authentication Authentication { get; set; }
        public void OnGet() {}
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = _userRepository.GetUserByLoginAndPassword(Authentication.Login, Authentication.Password);
                if (user != null)
                {
                    await Authenticate(user);
                    switch (user.Role)
                    {
                        case Role.Client:
                            return RedirectToPage("/Index");
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
        private async Task Authenticate(User user)
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
