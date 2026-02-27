using App.Data.Context;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Edit([FromForm] object editMyProfileModel)
        {
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
