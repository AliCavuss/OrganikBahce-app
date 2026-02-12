using Microsoft.AspNetCore.Mvc;

namespace OrganikBahce.MVC.Controllers
{
    public class ProductController : Controller
    {
       // [HttpGet("product/create")]
        public IActionResult Create()
        {
            return View();
        }

     //   [HttpGet("product/{id:int}/edit")]
        public IActionResult Edit()
        {
            return View();
        }

      //  [ValidateAntiForgeryToken]
        //[HttpPost("product/{id:int}/delete")]
        public IActionResult Delete()
        {
            return View();
        }

      //  [HttpPost("product/{id:int}/comment")]
        public IActionResult Comment()
        {
            return View();
        }

        public IActionResult Bestseller()
        {
            return View();
        }
    }
}
