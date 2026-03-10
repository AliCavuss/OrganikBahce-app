using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganikBahce.MVC.Models.ViewModels;

namespace OrganikBahce.MVC.ViewComponents
{
    public class LowStockProductsViewComponent : ViewComponent
    {
        private readonly OrganikBahceDbContext _context;

        public LowStockProductsViewComponent(OrganikBahceDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var lowStockProducts = await _context.Products
                .Where(x => x.StockAmount < 10)
                .OrderBy(x => x.StockAmount)
                .Select(x => new ProductListItemViewModel
                {
                    Id = x.Id,
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Price = x.Price,
                    StockAmount = x.StockAmount
                })
                .ToListAsync();

            return View(lowStockProducts);
        }
    }
}