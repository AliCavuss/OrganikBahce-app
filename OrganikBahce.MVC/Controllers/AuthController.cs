using Microsoft.AspNetCore.Mvc;

namespace OrganikBahce.MVC.Controllers
{
    public class AuthController : Controller
    {
        //[HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

       // [HttpGet("forgot-password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        //[HttpPost("logout")]
        //[ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            return View();
        }

    }
}
