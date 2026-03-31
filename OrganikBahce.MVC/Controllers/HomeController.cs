using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models;
using OrganikBahce.MVC.Models.ViewModels;
using App.Data.Entities;
using App.Data.Repositories;

using System.Net.Http.Json;

using System.Security.Claims;


namespace OrganikBahce.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataRepository<ProductEntity> _productRepository;

        public HomeController(IDataRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("/about-us")]
        [HttpGet]
        public IActionResult AboutUs()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("/contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [AllowAnonymous]
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

        [Authorize(Roles = "Buyer,Seller")]
        [Route("/product/list")]
        [HttpGet]
        public async Task<IActionResult> Listing(int? categoryId)
        {
            var client = new HttpClient();

            var products = await client.GetFromJsonAsync<List<ProductListItemViewModel>>(
                "https://localhost:7050/api/Product");

            // null gelirse boþ liste yap
            products ??= new List<ProductListItemViewModel>();

            // category filtreleme (eski koddan)
            if (categoryId.HasValue)
            {
                products = products
                    .Where(p => p.CategoryId == categoryId.Value)
                    .ToList();
            }

            return View(products);
        }

        [Authorize(Roles = "Buyer,Seller")]
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

        [AllowAnonymous]
        public IActionResult Testimonial()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Statistics()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("/debug-auth")]
        [HttpGet]
        public IActionResult DebugAuth()
        {
            var token = Request.Cookies["jwt_token"];

            var isAuthenticated = User.Identity?.IsAuthenticated ?? false;
            var name = User.Identity?.Name ?? "yok";
            var role = User.FindFirstValue(ClaimTypes.Role) ?? "yok";

            var authHeader = Request.Headers["Authorization"].ToString();
            var jwtError = Response.Headers["jwt-error"].ToString();

            return Content(
                $"Cookie var mý: {(string.IsNullOrEmpty(token) ? "YOK" : "VAR")}\n" +
                $"Authenticated: {isAuthenticated}\n" +
                $"Name: {name}\n" +
                $"Role: {role}\n" +
                $"Authorization Header: {(string.IsNullOrEmpty(authHeader) ? "YOK" : authHeader)}\n" +
                $"JWT Error: {(string.IsNullOrEmpty(jwtError) ? "YOK" : jwtError)}"
            );
        }
    }
}