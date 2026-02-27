using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.Controllers
{
    public class CartController : Controller
    {

        private readonly OrganikBahceDbContext _db;

        public CartController(OrganikBahceDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult AddProduct([FromRoute] int productId)
        {


            var prevUrl = Request.Headers.Referer.FirstOrDefault();

            if (prevUrl is null)
            {
                return RedirectToAction(nameof(Edit));
            }

            return Redirect(prevUrl);
        }



        [Route("/cart")]
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }


        [Route("/cart")]
        [HttpPost]
        public IActionResult Edit([FromForm]CartEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            return View();
        }
    }
}
