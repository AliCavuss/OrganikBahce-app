using Admin.Mvc.Models.ViewModels;
using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using App.Data.Entities;
using App.Data.Repositories;

namespace Admin.Mvc.Controllers
{
    public class AuthController : Controller
    {
        //private readonly OrganikBahceDbContext _db;

        //public AuthController(OrganikBahceDbContext db)
        //{
        //    _db = db;
        //}
        private readonly IDataRepository<UserEntity> _userRepository;
        public AuthController(IDataRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("/login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[Route("/login")]
        //[HttpPost]
        //public IActionResult Login([FromForm] AuthLoginViewModel loginModel)
        //{
        //    return View();
        //}

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> Login(AuthLoginViewModel loginModel)
        {
            if (!ModelState.IsValid)
                return View(loginModel);

            var users = await _userRepository.GetAllAsync();

            var user = users.FirstOrDefault(x =>
                x.Email == loginModel.Email &&
                x.Password == loginModel.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre hatalı.");
                return View(loginModel);
            }

            return RedirectToAction("Index", "Home");
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
