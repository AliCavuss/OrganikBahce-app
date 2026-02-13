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
    internal class ProductEntity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Id { get; set; }

        public int SellerId { get; set; }
        public int CategoryId { get; set; }


        [Required, StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }


        [Required, DataType(DataType.Currency)]
        public decimal Price { get; set; } // Datatype: Currency kısmına bakılacak?


        [MaxLength(1000)]
        public string Details { get; set; }


        [Required]
        public byte StockAmount { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; }


        [Required]
        public bool Enabled { get; set; }// Buraya Default:true annotations eklenecek!!!!!!!!!!!!!!!






        #region ForeignKey

        //[ForeignKey(nameof(RoleId))]
        [JsonIgnore] // bu olmadığında order ve customer'lar arasında sonsuz bir döngü oluşur.
        public UserEntity Seller { get; set; } // Seller ismi User mı olmalı?????

        [JsonIgnore]
        public CategoryEntity Category { get; set; }

        #endregion
    }
}
