using Admin.Mvc.Models;
using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataRepository<CategoryEntity> _categoryRepository;
        private readonly IDataRepository<ProductEntity> _productRepository;

        public HomeController(
            IDataRepository<CategoryEntity> categoryRepository,
            IDataRepository<ProductEntity> productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var products = await _productRepository.GetAllAsync();

            ViewBag.CategoryCount = categories.Count;
            ViewBag.ProductCount = products.Count;

            return View();
        }
    }
}

        //private readonly OrganikBahceDbContext _db;

        //public HomeController(OrganikBahceDbContext db)
        //{
        //    _db = db;
        //}

        //public IActionResult Index()
        //{
            
        //    ViewBag.CategoryCount = _db.Categories.Count();
        //    ViewBag.ProductCount = _db.Products.Count();

        //    return View();
        //}
  