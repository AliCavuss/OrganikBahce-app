using App.Data.Context;
using App.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly OrganikBahceDbContext _db;

        public ProductController(OrganikBahceDbContext db)
        {
            _db = db;
        }
        [Route("/product")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [Route("/product")]
        [HttpPost]
        public IActionResult Create([FromForm] ProductCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            return View();
        }

        [Route("/product/{productId:int}/edit")]
        [HttpGet]
        public IActionResult Edit([FromRoute] int productId)
        {
            return View();
        }

        [Route("/product/{productId:int}/edit")]
        [HttpPost]
        public IActionResult Edit([FromRoute] int productId, [FromForm] ProductEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            return View();
        }

        [Route("/product/{productId:int}/delete")]
        [HttpGet]
        public IActionResult Delete([FromRoute] int productId)
        {
            return View();
        }

        [HttpPost]
        [Route("/product/{productId:int}/comment")]
        public IActionResult Comment(int productId, ProductCommentCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("ProductDetail", "Home", new { productId });
            }

            var comment = new ProductCommentEntity
            {
                ProductId = productId,
                UserId = 1, // şimdilik sabit (login sistemi yoksa)
                Text = vm.Text,
                StarCount = (byte)vm.StarCount,
                CreatedAt = DateTime.Now
            };

            _db.Add(comment);
            _db.SaveChanges();

            return RedirectToAction("ProductDetail", "Home", new { productId });
        }

        public IActionResult Bestseller()
        {
            return View();
        }
    }
}
