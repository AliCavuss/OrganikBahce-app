using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    internal class CategoryEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Id { get; set; }


        [Required, StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }


        [Required, StringLength(6, MinimumLength = 3)]
        public string Color { get; set; }


        [Required, StringLength(50, MinimumLength = 2)]
        public string IconCssClass { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
