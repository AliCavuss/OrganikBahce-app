using System.ComponentModel.DataAnnotations;

namespace OrganikBahce.MVC.Models.ViewModels
{
    public class AuthForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; } = null!;
    }
}