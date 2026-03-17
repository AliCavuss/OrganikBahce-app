using Admin.Mvc.Controllers;
using App.Data.Context;
using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace Admin.Mvc.Controllers
{
    public class UserController : Controller
    {
    //    private readonly OrganikBahceDbContext _db;

    //    public UserController   (OrganikBahceDbContext db)
    //    {
    //        _db = db;
    //    }
    private readonly IDataRepository<UserEntity> _userRepository;
        public UserController(IDataRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }



        [Route("/users")]
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }

        //[Route("/users/{userId:int}/approve")]
        //[HttpGet]
        //public IActionResult Approve(int id)
        //{
        //    TempData["Success"] = $"Kullanıcı #{id} için satıcı onayı verildi .";
        //    return RedirectToAction("List", "User");
        //}

        [Route("/users/{userId:int}/approve")]
        [HttpGet]
        public async Task<IActionResult> Approve(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return NotFound();

            user.RoleId = 1; 
            user.Enabled = true;

            _userRepository.Update(user);
            await _userRepository.SaveAsync();

            TempData["Success"] = $"Kullanıcı #{userId} için satıcı onayı verildi.";
            return RedirectToAction("List", "User");
        }

    }
}
