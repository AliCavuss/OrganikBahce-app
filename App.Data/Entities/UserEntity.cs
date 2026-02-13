using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    internal class UserEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Id { get; set; }


        [Required, EmailAddress]
        public string Email { get; set; } =string.Empty;


        [Required, StringLength(50, MinimumLength =2)]
        public string FirstName { get; set; } = string.Empty;


        [Required, StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; } = string.Empty;


        [Required, MinLength(1)]
        public string Password { get; set; } = string.Empty;

        public int RoleId { get; set; }

        [Required, DefaultValue(true)]
        public bool Enabled { get; set; } // Buraya Default:true annotations eklenecek!!!!!!!!!!!!!!!

        [Required]
        public DateTime CreatedAt { get; set; }





        #region ForeignKey

        //[ForeignKey(nameof(RoleId))]
        [JsonIgnore] // bu olmadığında order ve customer'lar arasında sonsuz bir döngü oluşur.
        public RoleEntity Role { get; set; }

        #endregion

    }
}
