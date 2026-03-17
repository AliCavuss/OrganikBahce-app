using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using App.Data.Entities;
using App.Data.Repositories;

namespace Admin.Mvc.Controllers
{
    public class ProductController : Controller
    {
        //private readonly OrganikBahceDbContext _db;

        //public ProductController(OrganikBahceDbContext db)
        //{
        //    _db = db;
        //}

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
            // will return filtered products as json
            return Json(new { });
        }




        //---------------------------------------------------------------------
        //[Route("/product/{id:int}/delete")]
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var product = _db.Products.FirstOrDefault(x => x.Id == id);
        //    if (product == null)
        //        return NotFound();

        //    _db.Products.Remove(product);
        //    _db.SaveChanges();

        //    TempData["Success"] = "Ürün silindi.";
        //    return RedirectToAction("Index", "Home");
        //}
        //---------------------------------------------------------------------

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