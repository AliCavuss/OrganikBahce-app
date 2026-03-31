using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models.ViewModels;
using System.Text.Json;

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

        [Authorize(Roles = "Seller")]
        [Route("/product")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Seller")]
        [Route("/product")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            if (vm.ImageFile != null)
            {
                var client = new HttpClient();

                using var formData = new MultipartFormDataContent();
                formData.Add(
                    new StreamContent(vm.ImageFile.OpenReadStream()),
                    "file",
                    vm.ImageFile.FileName
                );

                var response = await client.PostAsync("https://localhost:7196/api/File/upload", formData);

                var result = await response.Content.ReadAsStringAsync();

                var json = JsonDocument.Parse(result);
                var fileName = json.RootElement.GetProperty("fileName").GetString();

                vm.ImageUrl = fileName;
            }

            var entity = new ProductEntity
            {
                SellerId = 1,
                CategoryId = vm.CategoryId,
                Name = vm.Name,
                Price = vm.Price,
                Details = vm.Details ?? string.Empty,
                StockAmount = vm.StockAmount,
                Enabled = true,
                ImageUrl = vm.ImageUrl
            };

            await _productRepository.AddAsync(entity);
            await _productRepository.SaveAsync();

            ViewBag.Message = "Ürün başarıyla eklendi.";

            ModelState.Clear();
            return View(new ProductCreateViewModel());
        }

        // ================= EDIT =================

        [Authorize(Roles = "Seller")]
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

        [Authorize(Roles = "Seller")]
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

        [Authorize(Roles = "Seller")]
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

        [Authorize(Roles = "Buyer,Seller")]
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
            await _commentRepository.SaveAsync();

            return RedirectToAction("ProductDetail", "Home", new { productId });
        }

        [AllowAnonymous]
        public IActionResult Bestseller()
        {
            return View();
        }
    }
}