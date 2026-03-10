using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class ProductEntity : EntityBase, IHasEnabled
    {
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; } 
        public string Details { get; set; } = null!;
        public byte StockAmount { get; set; }
        public bool Enabled { get; set; }






        #region ForeignKey


        public UserEntity Seller { get; set; } = null!;

       public CategoryEntity Category { get; set; } = null!;

        #endregion
    }
}
