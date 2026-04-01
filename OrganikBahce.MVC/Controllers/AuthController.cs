using System.Net;
using System.Net.Http.Json;

using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.Controllers
{
    public class AuthController : Controller
    {
      

        // ================= REGISTER =================

        [AllowAnonymous]
        [Route("/register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
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
        public async Task<IActionResult> Login(AuthLoginViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var client = new HttpClient();

            var response = await client.PostAsJsonAsync(
                "https://localhost:7050/api/Auth/login",
                new
                {
                    email = vm.Email,
                    password = vm.Password
                });

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre hatalı.");
                return View(vm);
            }

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Giriş sırasında bir hata oluştu.");
                return View(vm);
            }

            var result = await response.Content.ReadFromJsonAsync<LoginApiResponse>();



            if (result == null || string.IsNullOrWhiteSpace(result.Token))
            {
                ModelState.AddModelError(string.Empty, "API'den token gelmedi.");
                return View(vm);
            }

            Response.Cookies.Append("jwt_token", result.Token, new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTimeOffset.UtcNow.AddHours(2),
                Secure = false,
                SameSite = SameSiteMode.Lax,
                Path = "/"
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
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt_token");
            return RedirectToAction(nameof(Login));
        }
    }

    public class LoginApiResponse
    {
        public string Token { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
    }
}
//deneme