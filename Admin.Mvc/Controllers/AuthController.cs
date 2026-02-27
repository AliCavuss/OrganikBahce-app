using Admin.Mvc.Models.ViewModels;
using App.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Mvc.Controllers
{
    public class AuthController : Controller
    {
        private readonly OrganikBahceDbContext _db;

        public AuthController(OrganikBahceDbContext db)
        {
            _db = db;
        }

        [Route("/login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("/login")]
        [HttpPost]
        public IActionResult Login([FromForm] AuthLoginViewModel loginModel)
        {
            return View();
        }

        [Route("/logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            // logout kodları...

            return RedirectToAction(nameof(Login));
        }
    }
}
