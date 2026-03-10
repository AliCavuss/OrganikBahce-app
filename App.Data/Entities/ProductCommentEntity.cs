using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class ProductCommentEntity : EntityBase
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; } = null!;
        public byte StarCount { get; set; }
        public bool IsConfirmed { get; set; }



        #region ForeignKey

     
        public ProductEntity Product { get; set; } = null!;
        public UserEntity User { get; set; } = null!;


        #endregion
    }
}
