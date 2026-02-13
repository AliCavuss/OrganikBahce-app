using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    internal class RoleEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Id { get; set; }


        [Required, StringLength(10, MinimumLength = 2)]
        public int Name { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
