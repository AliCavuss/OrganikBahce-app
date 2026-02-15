using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OrderCode { get; set; } =string.Empty;
        public string Address { get; set; } =string.Empty;
        public DateTime CreatedAt { get; set; }



        #region ForeignKey

        //[ForeignKey(nameof(UserId))]
        [JsonIgnore]
        public UserEntity User { get; set; } = null!;


        #endregion
    }
}
