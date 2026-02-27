using System.ComponentModel.DataAnnotations;

namespace OrganikBahce.MVC.Models.ViewModels
{
    public class CartEditViewModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir ürün seçiniz.")]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 255, ErrorMessage = "Adet 1 ile 255 arasında olmalıdır.")]
        public int Quantity { get; set; }
    }
}