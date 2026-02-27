using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [Route("/about-us")]
        [HttpGet]
        public IActionResult AboutUs()
        {
            return View();
        }

        [Route("/contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("/contact")]
        [HttpPost]
        public IActionResult Contact([FromForm] HomeContactViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            return View();
        }

        [Route("/product/list")]
        [HttpGet]
        public IActionResult Listing()
        {
            return View();
        }

        [Route("/product/{productId:int}")]
        [HttpGet]
        public IActionResult ProductDetail(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

      

        public IActionResult Testimonial()
        {
            return View();
        }

        public IActionResult Statistics()
        {
            return View();        
        }
    }
}
