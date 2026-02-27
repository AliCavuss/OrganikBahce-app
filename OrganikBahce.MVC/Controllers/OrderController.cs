using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrganikBahceDbContext _db;

        public OrderController(OrganikBahceDbContext db)
        {
            _db = db;
        }

        [Route("/order")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [Route("/order")]
        [HttpPost]
        public IActionResult Create(OrderCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var orderId = 1; // şimdilik sabit
            return RedirectToAction(nameof(Details), new { orderId = orderId });
        }

        [Route("/order/{orderId:int}/details")]
        [HttpGet]
        public IActionResult Details([FromRoute] int orderId)
        {
            return View();
        }
    }
}
