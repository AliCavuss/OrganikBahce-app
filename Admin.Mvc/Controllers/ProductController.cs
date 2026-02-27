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
        public IActionResult Delete(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
