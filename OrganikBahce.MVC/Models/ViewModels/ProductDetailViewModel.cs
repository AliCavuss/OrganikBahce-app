using System.Collections.Generic;

namespace OrganikBahce.MVC.Models.ViewModels
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Details { get; set; } = string.Empty;
        public byte StockAmount { get; set; }

        // ⭐ Yorum formu için
        public ProductCommentCreateViewModel NewComment { get; set; } = new();

       
    }
}