using System.Security.Claims;
using Admin.Mvc.Models.ViewModels;
using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly IDataRepository<UserEntity> _userRepository;

        public AuthController(IDataRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [Route("/login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login(AuthLoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
                return View(loginModel);

            var users = await _userRepository.GetAllAsync();

            var user = users.FirstOrDefault(x =>
                x.Email == loginModel.Email &&
                x.Password == loginModel.Password &&
                x.Enabled);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre hatalı.");
                return View(loginModel);
            }

            string roleName = user.RoleId switch
            {
                1 => "Buyer",
                2 => "Seller",
                3 => "Admin",
                _ => ""
            };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, roleName)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(2)
                });

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [Route("/logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}