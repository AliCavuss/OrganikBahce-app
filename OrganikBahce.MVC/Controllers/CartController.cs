using App.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace OrganikBahce.MVC.Controllers
{
    public class CartController : Controller
    {

        private readonly OrganikBahceDbContext _db;

        public CartController(OrganikBahceDbContext db)
        {
            _db = db;
        }

        //[Route("/add-to-cart/{productId:int}", Name = "AddToCart")]
        //[HttpGet]
        //public IActionResult AddProduct([FromRoute] int productId)
        //{


        //    var prevUrl = Request.Headers.Referer.FirstOrDefault();

        //    if (prevUrl is null)
        //    {
        //        return RedirectToAction(nameof(Edit));
        //    }

        //    return Redirect(prevUrl);
        //}

        public IActionResult AddProduct()
        { 
            return View();
        }



        [Route("/cart")]
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [Route("/cart")]
        [HttpPost]
        public IActionResult Edit([FromForm] object editCartModel)
        {
            return View();
        }
    }
}
