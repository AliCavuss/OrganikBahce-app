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

        [HttpGet("/product/{id:int}/delete")]
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