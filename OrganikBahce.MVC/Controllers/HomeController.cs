using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models;
using OrganikBahce.MVC.Models.ViewModels;
using App.Data.Context;

namespace OrganikBahce.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrganikBahceDbContext _db;

        public HomeController(OrganikBahceDbContext db)
        {
            _db = db;
        }

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
        [ValidateAntiForgeryToken]
        public IActionResult Contact([FromForm] HomeContactViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            TempData["Message"] = "Mesajýnýz alýnmýþtýr.";
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
            var vm = _db.Products
                .Where(p => p.Id == productId)
                .Select(p => new ProductDetailViewModel
                {
                    Id = p.Id,
                    SellerId = p.SellerId,
                    CategoryId = p.CategoryId,
                    Name = p.Name,
                    Price = p.Price,
                    Details = p.Details,
                    StockAmount = p.StockAmount
                })
                .FirstOrDefault();

            if (vm == null)
                return NotFound();

            return View(vm);
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