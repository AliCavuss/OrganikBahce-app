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

        // ================= CREATE =================

        [Route("/product")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/product")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] ProductCreateViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var entity = new ProductEntity
            {
                SellerId = vm.SellerId,
                CategoryId = vm.CategoryId,
                Name = vm.Name,
                Price = vm.Price,
                Details = vm.Details ?? string.Empty,
                StockAmount = vm.StockAmount,
                CreatedAt = DateTime.Now,
                Enabled = true
            };

            _db.Products.Add(entity);
            _db.SaveChanges();

            
            ViewBag.Message = "Ürün başarıyla eklendi.";

           
            ModelState.Clear();
            return View(new ProductCreateViewModel());
        }

        // ================= EDIT =================

        [Route("/product/{productId:int}/edit")]
        [HttpGet]
        public IActionResult Edit([FromRoute] int productId)
        {
            var entity = _db.Products.Find(productId);
            if (entity == null)
                return NotFound();

            var vm = new ProductEditViewModel
            {
                Id = entity.Id,
                SellerId = entity.SellerId,
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                Price = entity.Price,
                Details = entity.Details,
                StockAmount = entity.StockAmount
            };

            return View(vm);
        }

        [Route("/product/{productId:int}/edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int productId, [FromForm] ProductEditViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var entity = _db.Products.Find(productId);
            if (entity == null)
                return NotFound();

            entity.SellerId = vm.SellerId;
            entity.CategoryId = vm.CategoryId;
            entity.Name = vm.Name;
            entity.Price = vm.Price;
            entity.Details = vm.Details ?? string.Empty;
            entity.StockAmount = vm.StockAmount;

            _db.SaveChanges();

           
            ViewBag.Message = "Ürün başarıyla güncellendi.";

            return View(vm);
        }

        // ================= DELETE =================

        [Route("/product/{productId:int}/delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([FromRoute] int productId)
        {
            var entity = _db.Products.Find(productId);

            if (entity == null)
            {
                ViewBag.Message = "Ürün bulunamadı.";
                return View("Delete");
            }

            _db.Products.Remove(entity);
            _db.SaveChanges();

            ViewBag.Message = "Ürün başarıyla silindi.";

            // Delete view model bekliyorsa göndermek daha doğru:
            return View("Delete", entity);
        }

        // ================= COMMENT =================

        [HttpPost]
        [Route("/product/{productId:int}/comment")]
        [ValidateAntiForgeryToken]
        public IActionResult Comment(int productId, [FromForm] ProductDetailViewModel vm)
        {
           
            if (!TryValidateModel(vm.NewComment, prefix: "NewComment"))
            {
                ViewBag.Message = "Yorum alanlarını kontrol et.";
                
                return RedirectToAction("ProductDetail", "Home", new { productId });
            }

            var comment = new ProductCommentEntity
            {
                ProductId = productId,
                UserId = 1,
                Text = vm.NewComment.Text,
                StarCount = (byte)vm.NewComment.StarCount,
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