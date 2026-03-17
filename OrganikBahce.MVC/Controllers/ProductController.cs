using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDataRepository<ProductEntity> _productRepository;
        private readonly IDataRepository<ProductCommentEntity> _commentRepository;

        public ProductController(
            IDataRepository<ProductEntity> productRepository,
            IDataRepository<ProductCommentEntity> commentRepository)
        {
            _productRepository = productRepository;
            _commentRepository = commentRepository;
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
        public async Task<IActionResult> Create(ProductCreateViewModel vm)
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

            await _productRepository.AddAsync(entity);

            ViewBag.Message = "Ürün başarıyla eklendi.";

            ModelState.Clear();
            return View(new ProductCreateViewModel());
        }

        // ================= EDIT =================

        [Route("/product/{productId:int}/edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(int productId)
        {
            var products = await _productRepository.GetAllAsync();
            var entity = products.FirstOrDefault(x => x.Id == productId);

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
        public async Task<IActionResult> Edit(int productId, ProductEditViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var products = await _productRepository.GetAllAsync();
            var entity = products.FirstOrDefault(x => x.Id == productId);

            if (entity == null)
                return NotFound();

            entity.SellerId = vm.SellerId;
            entity.CategoryId = vm.CategoryId;
            entity.Name = vm.Name;
            entity.Price = vm.Price;
            entity.Details = vm.Details ?? string.Empty;
            entity.StockAmount = vm.StockAmount;

            _productRepository.Update(entity);
            await _productRepository.SaveAsync();

            ViewBag.Message = "Ürün başarıyla güncellendi.";

            return View(vm);
        }

        // ================= DELETE =================

        [Route("/product/{productId:int}/delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int productId)
        {
            var products = await _productRepository.GetAllAsync();
            var entity = products.FirstOrDefault(x => x.Id == productId);

            if (entity == null)
            {
                ViewBag.Message = "Ürün bulunamadı.";
                return View("Delete");
            }

            _productRepository.Delete(entity);
            await _productRepository.SaveAsync();

            ViewBag.Message = "Ürün başarıyla silindi.";

            return View("Delete", entity);
        }

        // ================= COMMENT =================

        [HttpPost]
        [Route("/product/{productId:int}/comment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comment(int productId, ProductDetailViewModel vm)
        {
            if (!TryValidateModel(vm.NewComment, prefix: "NewComment"))
            {
                return RedirectToAction("ProductDetail", "Home", new { productId });
            }

            var comment = new ProductCommentEntity
            {
                ProductId = productId,
                UserId = 1,
                Text = vm.NewComment.Text,
                StarCount = (byte)vm.NewComment.StarCount,
                CreatedAt = DateTime.Now,
                IsConfirmed = false
            };

            await _commentRepository.AddAsync(comment);

            return RedirectToAction("ProductDetail", "Home", new { productId });
        }

        public IActionResult Bestseller()
        {
            return View();
        }
    }
}