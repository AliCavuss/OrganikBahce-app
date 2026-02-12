using Microsoft.AspNetCore.Mvc;

namespace Admin.Mvc.Controllers
{
    public class UserController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Approve(int id)
        {
            TempData["Success"] = $"Kullanıcı #{id} için satıcı onayı verildi .";
            return RedirectToAction("List", "User");
        }
    }
}
