using Admin.Mvc.Models.ViewModels;
using App.Data.Context;
using App.Data.Entities;
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

        // ================= CREATE =================
        [Route("/category/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CategoryCreateViewModel());
        }

        [HttpPost("/category/create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryCreateViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            
            var exists = _db.Categories.Any(x => x.Name == vm.Name);
            if (exists)
            {
                ModelState.AddModelError(nameof(vm.Name), "Bu isimde bir kategori zaten var.");
                return View(vm);
            }

            var entity = new CategoryEntity
            {
                Name = vm.Name,
                Color = vm.Color ?? string.Empty,
                IconCssClass = vm.IconCssClass ?? string.Empty,
                CreatedAt = DateTime.Now
            };

            _db.Categories.Add(entity);
            _db.SaveChanges();

            TempData["Success"] = "Kategori başarıyla oluşturuldu.";
            return RedirectToAction(nameof(Edit), new { id = entity.Id });
        }

        // ================= EDIT =================

        [Route("/category/{id:int}/edit")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
                return NotFound();

            var vm = new CategoryEditViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Color = category.Color,
                IconCssClass = category.IconCssClass
            };

            return View(vm);
        }

        [Route("/category/{id:int}/edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryEditViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var category = _db.Categories.FirstOrDefault(x => x.Id == vm.Id);
            if (category == null)
                return NotFound();

           
            var nameTaken = _db.Categories.Any(x => x.Name == vm.Name && x.Id != vm.Id);
            if (nameTaken)
            {
                ModelState.AddModelError(nameof(vm.Name), "Bu isimde başka bir kategori var.");
                return View(vm);
            }

            category.Name = vm.Name;
            category.Color = vm.Color ?? string.Empty;
            category.IconCssClass = vm.IconCssClass ?? string.Empty;

            _db.SaveChanges();

            TempData["Success"] = "Kategori güncellendi.";
            return RedirectToAction(nameof(Edit), new { id = vm.Id });
        }

        // ================= DELETE =================

        [Route("/category/{id:int}/delete")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
                return NotFound();

            _db.Categories.Remove(category);
            _db.SaveChanges();

            TempData["Success"] = "Kategori silindi.";
            return RedirectToAction("Index", "Home");
        }
    }
}