using System;
using App.Data;
using App.Data.Context;
using App.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OrganikBahce.MVC.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly OrganikBahceDbContext _context;

        public CategoryMenuViewComponent(OrganikBahceDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories               
                .OrderBy(x => x.Name)
                .ToListAsync();

            return View(categories);
        }
    }
}
