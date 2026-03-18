using System.Security.Claims;
using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IDataRepository<UserEntity> _userRepository;

        public AuthController(IDataRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        // ================= REGISTER =================

        [AllowAnonymous]
        [Route("/register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> Register(AuthRegisterViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var users = await _userRepository.GetAllAsync();

            var exists = users.Any(x => x.Email == vm.Email);
            if (exists)
            {
                ModelState.AddModelError(nameof(vm.Email), "Bu email zaten kayıtlı.");
                return View(vm);
            }

            var user = new UserEntity
            {
                Email = vm.Email,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Password = vm.Password,
                RoleId = 1,
                CreatedAt = DateTime.Now,
                Enabled = true
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();

            return RedirectToAction(nameof(Login));
        }

        // ================= LOGIN =================

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
        public async Task<IActionResult> Login(AuthLoginViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var users = await _userRepository.GetAllAsync();

            var user = users.FirstOrDefault(x =>
                x.Email == vm.Email &&
                x.Password == vm.Password &&
                x.Enabled);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre hatalı.");
                return View(vm);
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

        // ================= FORGOT PASSWORD =================

        [AllowAnonymous]
        [Route("/forgot-password")]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("/forgot-password")]
        [HttpPost]
        public IActionResult ForgotPassword(AuthForgotPasswordViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            return View();
        }

        // ================= RENEW PASSWORD =================

        [AllowAnonymous]
        [Route("/renew-password/{verificationCode}")]
        [HttpGet]
        public IActionResult RenewPassword(string verificationCode)
        {
            ViewBag.VerificationCode = verificationCode;
            return View();
        }

        [AllowAnonymous]
        [Route("/renew-password")]
        [HttpPost]
        public IActionResult RenewPassword(AuthRenewPasswordViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            return View();
        }

        // ================= LOGOUT =================

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