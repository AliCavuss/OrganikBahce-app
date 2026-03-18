using System.Security.Claims;
using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.Controllers
{
    [Authorize(Roles = "Buyer,Seller")]
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
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdClaim))
            {
                return RedirectToAction("Login", "Auth");
            }

            var userId = int.Parse(userIdClaim);

            var cartItem = new CartItemEntity
            {
                ProductId = productId,
                UserId = userId,
                Quantity = 1,
                CreatedAt = DateTime.Now
            };

            await _cartRepository.AddAsync(cartItem);
            await _cartRepository.SaveAsync();

            var prevUrl = Request.Headers.Referer.FirstOrDefault();

            if (string.IsNullOrEmpty(prevUrl))
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

            return View(vm);
        }
    }
}