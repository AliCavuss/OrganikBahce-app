using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
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