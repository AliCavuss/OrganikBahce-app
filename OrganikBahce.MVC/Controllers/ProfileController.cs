using Microsoft.AspNetCore.Mvc;

namespace OrganikBahce.MVC.Controllers
{
    public class ProfileController : Controller
    {

       // [HttpGet("profile")]
        public IActionResult Details()
        {
            return View();
        }

      //  [HttpGet("profile/edit")]
        public IActionResult Edit()
        {
            return View();
        }

       // [HttpGet("profile/orders")]
        public IActionResult MyOrders()
        {
            return View();
        }

       // [HttpGet("profile/products")]
        public IActionResult MyProducts()
        {
            return View();
        }
    }
}
