using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.Controllers
{
    public class ProfileController : Controller
    {
        private readonly OrganikBahceDbContext _db;

        public ProfileController(OrganikBahceDbContext db)
        {
            _db = db;
        }

        [Route("/profile")]
        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
        [Route("/profile")]
        [HttpPost]
        public IActionResult Edit(ProfileEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            return RedirectToAction(nameof(Details));
        }

        [Route("/my-orders")]
        [HttpGet]
        public IActionResult MyOrders()
        {
            return View();
        }

        [Route("/my-products")]
        [HttpGet]
        public IActionResult MyProducts()
        {
            return View();
        }
    }
}
