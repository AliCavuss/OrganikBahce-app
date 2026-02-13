using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    internal class OrderEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Id { get; set; }
        public int UserId { get; set; }


        [Required, MinLength(2)]
        public string OrderCode { get; set; }


        [Required, StringLength(250,MinimumLength =2)]
        public string Address { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }



        #region ForeignKey

        //[ForeignKey(nameof(UserId))]
        [JsonIgnore] // bu olmadığında order ve customer'lar arasında sonsuz bir döngü oluşur.
        public UserEntity User { get; set; }


        #endregion
    }
}
