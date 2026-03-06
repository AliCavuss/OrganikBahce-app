using App.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Mvc.Controllers
{
    public class CommentController : Controller
    {
        private readonly OrganikBahceDbContext _db;

        public CommentController(OrganikBahceDbContext db)
        {
            _db = db;
        }

        [Route("/comment")]
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        [Route("/comment/{commentId:int}/approve")]
        [HttpGet]
        public IActionResult Approve(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
