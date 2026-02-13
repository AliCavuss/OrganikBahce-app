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
    internal class ProductImageEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Id { get; set; }
        public int ProductId { get; set; }

        [Required, StringLength(250, MinimumLength =10)] // datatype:Url annotations gelecek
        public string Url { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }




        #region ForeignKey

        //[ForeignKey(nameof(ProductId))]
        [JsonIgnore] // bu olmadığında order ve customer'lar arasında sonsuz bir döngü oluşur.
        public ProductEntity Product { get; set; } 
   

        #endregion
    }
}
