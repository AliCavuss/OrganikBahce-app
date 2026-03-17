using App.Data.Entities;
using App.Data.Repositories;
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

        [Route("/register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

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

            return RedirectToAction(nameof(Login));
        }

        // ================= LOGIN =================

        [Route("/login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login(AuthLoginViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var users = await _userRepository.GetAllAsync();

            var user = users.FirstOrDefault(x =>
                x.Email == vm.Email &&
                x.Password == vm.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre hatalı.");
                return View(vm);
            }

            return RedirectToAction("Index", "Home");
        }

        // ================= FORGOT PASSWORD =================

        [Route("/forgot-password")]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("/forgot-password")]
        [HttpPost]
        public IActionResult ForgotPassword(AuthForgotPasswordViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            return View();
        }

        // ================= RENEW PASSWORD =================

        [Route("/renew-password/{verificationCode}")]
        [HttpGet]
        public IActionResult RenewPassword(string verificationCode)
        {
            ViewBag.VerificationCode = verificationCode;
            return View();
        }

        [Route("/renew-password")]
        [HttpPost]
        public IActionResult RenewPassword(AuthRenewPasswordViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            return View();
        }

        // ================= LOGOUT =================

        [Route("/logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            return RedirectToAction(nameof(Login));
        }
    }
}