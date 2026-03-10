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
    public class CartItemEntity : EntityBase
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public byte Quantity { get; set; }




        #region ForeignKey
       
        public ProductEntity Product { get; set; } = null!;
        public UserEntity User { get; set; } = null!;

        #endregion
    }
}
