using Admin.Mvc.Models;
using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Admin.Mvc.Controllers
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
            
            ViewBag.CategoryCount = _db.Categories.Count();
            ViewBag.ProductCount = _db.Products.Count();

            return View();
        }
    }
}