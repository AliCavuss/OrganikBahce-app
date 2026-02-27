using System.ComponentModel.DataAnnotations;

namespace OrganikBahce.MVC.Models.ViewModels
{
    public class HomeContactViewModel
    {
        [Required]
        [MaxLength(200)]
        public string FullName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(200)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(2000)]
        public string Message { get; set; } = null!;
    }
}