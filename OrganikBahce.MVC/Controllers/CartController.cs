using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly IDataRepository<CartItemEntity> _cartRepository;

        public CartController(IDataRepository<CartItemEntity> cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [Route("/add-to-cart/{productId:int}")]
        [HttpGet]
        public async Task<IActionResult> AddProduct(int productId)
        {
            var cartItem = new CartItemEntity
            {
                ProductId = productId,
                UserId = 1, 
                Quantity = 1,
                CreatedAt = DateTime.Now
            };

            await _cartRepository.AddAsync(cartItem);
            await _cartRepository.SaveAsync();

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
        public IActionResult Edit(CartEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            return View();
        }
    }
}








//namespace OrganikBahce.MVC.Controllers
//{
//    public class CartController : Controller
//    {

//        private readonly OrganikBahceDbContext _db;

//        public CartController(OrganikBahceDbContext db)
//        {
//            _db = db;
//        }


//        [HttpGet]
//        public IActionResult AddProduct([FromRoute] int productId)
//        {


//            var prevUrl = Request.Headers.Referer.FirstOrDefault();

//            if (prevUrl is null)
//            {
//                return RedirectToAction(nameof(Edit));
//            }

//            return Redirect(prevUrl);
//        }



//        [Route("/cart")]
//        [HttpGet]
//        public IActionResult Edit()
//        {
//            return View();
//        }


//        [Route("/cart")]
//        [HttpPost]
//        public IActionResult Edit([FromForm]CartEditViewModel vm)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(vm);
//            }
//            return View();
//        }
//    }
//}
