using System.ComponentModel.DataAnnotations;

namespace OrganikBahce.MVC.Models.ViewModels
{
    public class OrderCreateViewModel
    {
        [Required]
        [MaxLength(250)]
        public string Address { get; set; } = null!;
    }
}

//using System.ComponentModel.DataAnnotations;

//namespace OrganikBahce.MVC.Models.ViewModels
//{
//    public class OrderCreateViewModel
//    {
//        [Required]
//        [MaxLength(200)]
//        public string FullName { get; set; } = null!;

//        [Required]
//        [MaxLength(500)]
//        public string Address { get; set; } = null!;

//        [Required]
//        [MaxLength(100)]
//        public string City { get; set; } = null!;

//        [Required]
//        [Phone]
//        [MaxLength(20)]
//        public string Phone { get; set; } = null!;
//    }
//}