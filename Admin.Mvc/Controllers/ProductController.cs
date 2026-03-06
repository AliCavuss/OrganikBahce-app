using App.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly OrganikBahceDbContext _db;

        public ProductController(OrganikBahceDbContext db)
        {
            _db = db;
        }


        //---------------------------yeni eklendi.
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

        //-------------------------yeni eklendi.



        [Route("/product/{id:int}/delete")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = _db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();

            _db.Products.Remove(product);
            _db.SaveChanges();

            TempData["Success"] = "Ürün silindi.";
            return RedirectToAction("Index", "Home");
        }
    }
}