using System.ComponentModel.DataAnnotations;

namespace OrganikBahce.MVC.Models.ViewModels
{
    public class AuthRegisterViewModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string PasswordAgain { get; set; } = null!;
    }
}
