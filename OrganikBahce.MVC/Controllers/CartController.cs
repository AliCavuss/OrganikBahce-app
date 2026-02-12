using Microsoft.AspNetCore.Mvc;

namespace OrganikBahce.MVC.Controllers
{
    public class CartController : Controller
    {
        //[HttpPost("cart/add/{productId:int}")]
        public IActionResult AddProduct()
        {
            return View();
        }


       // [HttpGet("cart")]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
