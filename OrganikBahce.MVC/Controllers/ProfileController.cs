using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IDataRepository<UserEntity> _userRepository;
        private readonly IDataRepository<OrderEntity> _orderRepository;
        private readonly IDataRepository<ProductEntity> _productRepository;

        public ProfileController(
            IDataRepository<UserEntity> userRepository,
            IDataRepository<OrderEntity> orderRepository,
            IDataRepository<ProductEntity> productRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        [Route("/profile")]
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var user = await _userRepository.GetByIdAsync(1);
            if (user == null)
                return NotFound();

            var vm = new ProfileEditViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return View(vm);
        }

        [Route("/profile")]
        [HttpPost]
        public async Task<IActionResult> Edit(ProfileEditViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Details", vm);
            }

            var user = await _userRepository.GetByIdAsync(1);
            if (user == null)
                return NotFound();

            user.FirstName = vm.FirstName;
            user.LastName = vm.LastName;
            user.Email = vm.Email;

            _userRepository.Update(user);
            await _userRepository.SaveAsync();

            return RedirectToAction(nameof(Details));
        }

        [Authorize(Roles = "Buyer,Seller")]
        [Route("/my-orders")]
        [HttpGet]
        public async Task<IActionResult> MyOrders()
        {
            var orders = await _orderRepository.GetAllAsync();
            var myOrders = orders.Where(x => x.UserId == 1).ToList();

            return View(myOrders);
        }

        [Authorize(Roles = "Seller")]
        [Route("/my-products")]
        [HttpGet]
        public async Task<IActionResult> MyProducts()
        {
            var products = await _productRepository.GetAllAsync();
            var myProducts = products.Where(x => x.SellerId == 1).ToList();

            return View(myProducts);
        }
    }
}