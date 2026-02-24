using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models;

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
        public IActionResult Contact([FromForm] object newContactMessageModel)
        {
            return View();
        }

        [Route("/product/list")]
        [HttpGet]
        public IActionResult Listing()
        {
            return View();
        }

        [Route("/product/{productId:int}/details")]
        [HttpGet]
        public IActionResult ProductDetail()
        {
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
