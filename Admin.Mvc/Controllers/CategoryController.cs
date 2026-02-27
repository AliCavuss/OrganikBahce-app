using Admin.Mvc.Models.ViewModels;
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

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel vm)
        {
            return View();
        }
        public IActionResult Edit(CategoryEditViewModel vm)
        {
          
            return View();
        }
        public IActionResult Delete(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
