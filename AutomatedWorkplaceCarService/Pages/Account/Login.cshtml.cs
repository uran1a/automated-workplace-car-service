using AutoMapper;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AutomatedWorkplaceCarService.WEB.Pages.Account
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
        public Models.AuthenticationModel Authentication { get; set; }
        public void OnGet() {}
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userDTO = await _authentificationService.GetUserAsync(Authentication.Login, Authentication.Password);
                var user = _mapper.Map<UserModel>(userDTO);
                if (user != null)
                {
                    await Authenticate(user);

                    var roleDTO = await _authentificationService.GetRoleAsync(user.RoleId);
                    if(roleDTO == null)
                        return RedirectToPage("/Error");
                    var availableRoles = await _authentificationService.GetAllRolesAsync();

                    if (user.RoleId == availableRoles["client"])
                        return RedirectToPage("/Clients/Applications");
                    else if(user.RoleId == availableRoles["admin"])
                        return RedirectToPage("/Employees/Admin/Clients");
                    else if(user.RoleId == availableRoles["employee"])
                        return RedirectToPage("/Employees/Employee/Applications");
                    else
                        return RedirectToPage("/Error");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return Page();
        }
        private async Task Authenticate(UserModel user)
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
