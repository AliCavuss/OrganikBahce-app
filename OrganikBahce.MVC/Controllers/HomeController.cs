using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models;

namespace OrganikBahce.MVC.Controllers
{
    public class HomeController : Controller
    {
        // [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        // [HttpGet("about-us")]

        public IActionResult AboutUs()
        {
            return View();
        }

        // [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        // [HttpGet("products")]
        public IActionResult Listing()
        {
            return View();
        }

        // [HttpGet("product/{categoryName}-{title}-{id:int}/details")]
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
