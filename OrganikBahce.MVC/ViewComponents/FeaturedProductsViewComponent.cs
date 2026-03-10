using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.ViewComponents
{
    public class FeaturedProductsViewComponent : ViewComponent
    {
        private readonly OrganikBahceDbContext _context;

        public FeaturedProductsViewComponent(OrganikBahceDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _context.Products
                .OrderBy(x => x.Id)
                .Take(6)
                .Select(x => new ProductListItemViewModel
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Price = x.Price,
                    StockAmount = x.StockAmount
                })
                .ToListAsync();

            return View(products);
        }
    }
}