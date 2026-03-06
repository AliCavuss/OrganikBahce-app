using App.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly OrganikBahceDbContext _db;

        public UserController   (OrganikBahceDbContext db)
        {
            _db = db;
        }

        [Route("/users")]
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [Route("/users/{userId:int}/approve")]
        [HttpGet]
        public IActionResult Approve(int id)
        {
            TempData["Success"] = $"Kullanıcı #{id} için satıcı onayı verildi .";
            return RedirectToAction("List", "User");
        }
    }
}
