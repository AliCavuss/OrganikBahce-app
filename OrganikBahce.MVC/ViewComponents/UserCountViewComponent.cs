using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OrganikBahce.MVC.ViewComponents
{
    public class UserCountViewComponent : ViewComponent
    {
        private readonly OrganikBahceDbContext _context;

        public UserCountViewComponent(OrganikBahceDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userCount = await _context.Users.CountAsync();

            return View(userCount);
        }
    }
}