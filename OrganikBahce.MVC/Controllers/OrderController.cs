using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IDataRepository<OrderEntity> _orderRepository;

        public OrderController(IDataRepository<OrderEntity> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [Route("/order")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/order")]
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var entity = new OrderEntity
            {
                UserId = 1, // şimdilik sabit
                OrderCode = "AB",
                Address = vm.Address,
                CreatedAt = DateTime.Now
            };

            await _orderRepository.AddAsync(entity);
            await _orderRepository.SaveAsync();

            return RedirectToAction(nameof(Details), new { orderId = entity.Id });
        }

        [Route("/order/{orderId:int}/details")]
        [HttpGet]
        public async Task<IActionResult> Details(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                return NotFound();

            return View(order);
        }
    }
}








//namespace OrganikBahce.MVC.Controllers
//{
//    public class OrderController : Controller
//    {
//        private readonly OrganikBahceDbContext _db;

//        public OrderController(OrganikBahceDbContext db)
//        {
//            _db = db;
//        }

//        [Route("/order")]
//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View();
//        }


//        [Route("/order")]
//        [HttpPost]
//        public IActionResult Create(OrderCreateViewModel vm)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(vm);
//            }
//            var orderId = 1; // şimdilik sabit
//            return RedirectToAction(nameof(Details), new { orderId = orderId });
//        }

//        [Route("/order/{orderId:int}/details")]
//        [HttpGet]
//        public IActionResult Details([FromRoute] int orderId)
//        {
//            return View();
//        }
//    }
//}
