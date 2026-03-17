using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models;
using OrganikBahce.MVC.Models.ViewModels;
using App.Data.Entities;
using App.Data.Repositories;

namespace OrganikBahce.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataRepository<ProductEntity> _productRepository;

        public HomeController(IDataRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
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
        public IActionResult Contact(HomeContactViewModel vm)
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
        public async Task<IActionResult> Listing(int? categoryId)
        {
            var products = await _productRepository.GetAllAsync();

            if (categoryId.HasValue)
            {
                products = products
                    .Where(p => p.CategoryId == categoryId.Value)
                    .ToList();
            }

            var productList = products
                .Select(p => new ProductListItemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    StockAmount = p.StockAmount,
                    CategoryId = p.CategoryId
                })
                .ToList();

            return View(productList);
        }

        [Route("/product/{productId:int}")]
        [HttpGet]
        public async Task<IActionResult> ProductDetail(int productId)
        {
            var products = await _productRepository.GetAllAsync();

            var vm = products
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

