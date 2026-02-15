using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class OrderItemEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }




        #region ForeignKey

        //[ForeignKey(nameof(OrderId))]
        [JsonIgnore]
        public OrderEntity Order { get; set; } = null!;

        [JsonIgnore]
        public ProductEntity Product { get; set; } = null!;


        #endregion
    }
}
