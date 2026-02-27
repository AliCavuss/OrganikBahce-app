using System.ComponentModel.DataAnnotations;

namespace OrganikBahce.MVC.Models.ViewModels
{
    public class ProductEditViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int SellerId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0.01, 9999999999999999.99)]
        public decimal Price { get; set; }

        [MaxLength(1000)]
        public string? Details { get; set; }

        [Required]
        [Range(0, 255)]
        public byte StockAmount { get; set; }
    }
}