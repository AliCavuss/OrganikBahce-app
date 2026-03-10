using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class OrderEntity : EntityBase
    {
        public int UserId { get; set; }
        public string OrderCode { get; set; } = null!;
        public string Address { get; set; } = null!;



        #region ForeignKey

        public UserEntity User { get; set; } = null!;


        #endregion
    }
}
