using System.ComponentModel.DataAnnotations;

namespace OrganikBahce.MVC.Models.ViewModels
{
    public class ProfileEditViewModel
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
      
    }
}