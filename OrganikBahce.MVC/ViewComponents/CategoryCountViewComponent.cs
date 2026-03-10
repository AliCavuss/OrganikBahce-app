using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OrganikBahce.MVC.ViewComponents
{
    public class CategoryCountViewComponent : ViewComponent
    {
        private readonly OrganikBahceDbContext _context;

        public CategoryCountViewComponent(OrganikBahceDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryCount = await _context.Categories.CountAsync();

            return View(categoryCount);
        }
    }
}


//Veritabanındaki toplam kategori sayısını almak

//Sayfada küçük bir bilgi kutusu olarak göstermek