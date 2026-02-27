using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly OrganikBahceDbContext _db;

        public AuthController(OrganikBahceDbContext db)
        {
            _db = db;
        }

        [Route("/register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("/register")]
        [HttpPost]
        public IActionResult Register(AuthRegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            
            return View();
        }

        [Route("/login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/login")]
        [HttpPost]
        public IActionResult Login([FromForm] AuthLoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            return View();
        }
        [Route("/forgot-password")]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("/forgot-password")]
        [HttpPost]
        public IActionResult ForgotPassword([FromForm] AuthForgotPasswordViewModel vm )
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            return View();
        }

        [Route("/renew-password/{verificationCode}")]
        [HttpGet]
        public IActionResult RenewPassword(string verificationCode)
        {
            ViewBag.VerificationCode = verificationCode;
            return View();
        }

        [Route("/renew-password")]
        [HttpPost]
        public IActionResult RenewPassword([FromForm] AuthRenewPasswordViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            return View();
        }
        [Route("/logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            return RedirectToAction(nameof(Login));
        }

    }
}
