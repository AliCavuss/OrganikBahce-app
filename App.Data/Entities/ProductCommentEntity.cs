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
    internal class ProductCommentEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }


        [Required, StringLength(500, MinimumLength =2)]
        public string Text { get; set; }


        [Required, StringLength(5, MinimumLength = 1)]
        public byte StarCount { get; set; }

        [Required]
        public bool IsConfirmed { get; set; }// Buraya Default:true annotations eklenecek!!!!!!!!!!!!!!!

        [Required]
        public DateTime CreatedAt { get; set; }



        #region ForeignKey

        //[ForeignKey(nameof(ProductId))]
        [JsonIgnore] // bu olmadığında order ve customer'lar arasında sonsuz bir döngü oluşur.
        public ProductEntity Product { get; set; }

        [JsonIgnore]
        public UserEntity User { get; set; }


        #endregion
    }
}
