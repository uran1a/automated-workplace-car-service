using AutoMapper;
using AutomatedWorkplaceCarService.BLL.Interfaces;
using AutomatedWorkplaceCarService.WEB.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace AutomatedWorkplaceCarService.WEB.Pages.Account
{
    public class AuthenticationModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;
        public AuthenticationModel(IUserService userService, IRoleService roleService, IMapper mapper)
        {
            _userService = userService;
            _roleService = roleService;
            _mapper = mapper;
        }
        [BindProperty]
        public AuthenticationViewModel Authentication { get; set; }
        public void OnGet() {}
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userDTO = await _userService.GetUserAsync(Authentication.Login, Authentication.Password);
                var user = _mapper.Map<UserViewModel>(userDTO);
                if (user != null)
                {
                    await Authenticate(user);

                    var roleDTO = await _roleService.GetRoleAsync(user.RoleId);
                    if(roleDTO == null)
                        return RedirectToPage("/Error");
                    var availableRoles = await _roleService.GetAllRolesAsync();

                    if (user.RoleId == availableRoles["client"])
                        return RedirectToPage("/Clients/Applications");
                    else if(user.RoleId == availableRoles["admin"])
                        return RedirectToPage("/Employees/Admin/Clients");
                    else if(user.RoleId == availableRoles["employee"])
                        return RedirectToPage("/Employees/Master/Applications");
                    else
                        return RedirectToPage("/Error");
                }
                ModelState.AddModelError("", "������������ ����� �(���) ������");
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
