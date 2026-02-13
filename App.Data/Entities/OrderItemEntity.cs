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
    internal class OrderItemEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }


        [Required, MinLength(1)]
        public byte Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }// Datatype: Currency kısmına bakılacak?

        [Required]
        public DateTime CreatedAt { get; set; }




        #region ForeignKey

        //[ForeignKey(nameof(OrderId))]
        [JsonIgnore] // bu olmadığında order ve customer'lar arasında sonsuz bir döngü oluşur.
        public OrderEntity Order { get; set; }

        [JsonIgnore]
        public ProductEntity Product { get; set; }


        #endregion
    }
}
