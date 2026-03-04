using System.ComponentModel.DataAnnotations;

namespace Admin.Mvc.Models.ViewModels
{
    public class CategoryEditViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; } = null!;

        [StringLength(20, ErrorMessage = "Color en fazla 20 karakter olabilir.")]
        public string? Color { get; set; }

        [StringLength(100, ErrorMessage = "IconCssClass en fazla 100 karakter olabilir.")]
        public string? IconCssClass { get; set; }
    }
}