using App.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly OrganikBahceDbContext _db;

        public CategoryController(OrganikBahceDbContext db)
        {
            _db = db;
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult Delete(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
