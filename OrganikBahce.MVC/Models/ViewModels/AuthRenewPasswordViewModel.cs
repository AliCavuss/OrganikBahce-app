using System.ComponentModel.DataAnnotations;

namespace OrganikBahce.MVC.Models.ViewModels
{
    public class AuthRenewPasswordViewModel
    {
        [Required]
        [MaxLength(200)]
        public string VerificationCode { get; set; } = null!;

        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string NewPassword { get; set; } = null!;

        [Required]
        [Compare("NewPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string NewPasswordAgain { get; set; } = null!;
    }
}