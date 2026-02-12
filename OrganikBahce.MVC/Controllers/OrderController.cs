using Microsoft.AspNetCore.Mvc;

namespace OrganikBahce.MVC.Controllers
{
    public class OrderController : Controller
    {
       // [HttpGet("order/create")]
        public IActionResult Create()
        {
            return View();
        }
        //[HttpGet("order/{id:int}/details")]
        public IActionResult Details()
        {
            return View();
        }
    }
}
