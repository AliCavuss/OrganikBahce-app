using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class ProductImageEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [DataType(DataType.Url)]
        public string Url { get; set; } =string.Empty;
        public DateTime CreatedAt { get; set; }




        #region ForeignKey

        //[ForeignKey(nameof(ProductId))]
        [JsonIgnore] 
        public ProductEntity Product { get; set; } = null!;
   

        #endregion
    }
}
