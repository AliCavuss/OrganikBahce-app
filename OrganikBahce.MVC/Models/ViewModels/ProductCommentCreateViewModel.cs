using System.ComponentModel.DataAnnotations;

namespace OrganikBahce.MVC.Models.ViewModels
{
    public class ProductCommentCreateViewModel
    {
        [Required]
        [MaxLength(500)]
        public string Text { get; set; } = null!;

        [Required]
        [Range(1, 5, ErrorMessage = "Puan 1 ile 5 arasında olmalıdır.")]
        public int StarCount { get; set; }
    }
}