using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IDataRepository<ProductEntity> _productRepository;

        public ProductController(IDataRepository<ProductEntity> productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("/products/")]
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [Route("/products/filter")]
        [HttpGet]
        public IActionResult Filter([FromQuery] object filterOptions)
        {
            return Json(new { });
        }

        [Route("/product/{id:int}/delete")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();

            _productRepository.Delete(product);
            await _productRepository.SaveAsync();

            TempData["Success"] = "Ürün silindi.";
            return RedirectToAction("Index", "Home");
        }
    }
}