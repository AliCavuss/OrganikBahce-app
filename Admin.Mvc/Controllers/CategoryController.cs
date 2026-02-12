using Microsoft.AspNetCore.Mvc;

namespace Admin.Mvc.Controllers
{
    public class CategoryController : Controller
    {
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
