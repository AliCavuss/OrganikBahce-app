using Admin.Mvc.Models.ViewModels;
using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IDataRepository<CategoryEntity> _categoryRepository;

        public CategoryController(IDataRepository<CategoryEntity> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Route("/category/create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CategoryCreateViewModel());
        }

        [HttpPost("/category/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var categories = await _categoryRepository.GetAllAsync();

            var exists = categories.Any(x => x.Name == vm.Name);
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

            await _categoryRepository.AddAsync(entity);
            await _categoryRepository.SaveAsync();

            TempData["Success"] = "Kategori başarıyla oluşturuldu.";
            return RedirectToAction(nameof(Edit), new { id = entity.Id });
        }

        [Route("/category/{id:int}/edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
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
        public async Task<IActionResult> Edit(CategoryEditViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            var category = await _categoryRepository.GetByIdAsync(vm.Id);
            if (category == null)
                return NotFound();

            var categories = await _categoryRepository.GetAllAsync();

            var nameTaken = categories.Any(x => x.Name == vm.Name && x.Id != vm.Id);
            if (nameTaken)
            {
                ModelState.AddModelError(nameof(vm.Name), "Bu isimde başka bir kategori var.");
                return View(vm);
            }

            category.Name = vm.Name;
            category.Color = vm.Color ?? string.Empty;
            category.IconCssClass = vm.IconCssClass ?? string.Empty;

            _categoryRepository.Update(category);
            await _categoryRepository.SaveAsync();

            TempData["Success"] = "Kategori güncellendi.";
            return RedirectToAction(nameof(Edit), new { id = vm.Id });
        }

        [Route("/category/{id:int}/delete")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return NotFound();

            _categoryRepository.Delete(category);
            await _categoryRepository.SaveAsync();

            TempData["Success"] = "Kategori silindi.";
            return RedirectToAction("Index", "Home");
        }
    }
}