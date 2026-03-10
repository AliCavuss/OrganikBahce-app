using App.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OrganikBahce.MVC.ViewComponents
{
    public class ProductCountViewComponent : ViewComponent
    {
        private readonly OrganikBahceDbContext _context;

        public ProductCountViewComponent(OrganikBahceDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var productCount = await _context.Products.CountAsync();

            return View(productCount);
        }
    }
}

//Bu component’in görevi;

//veritabanındaki toplam ürün sayısını alacak

//ekranda gösterecek

//Şuralarda kullanılabilir:

//admin dashboard

//ana sayfa bilgi kutusu

//istatistik alanı

//sidebar