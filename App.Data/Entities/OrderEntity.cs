using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    internal class OrderEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string OrderCode { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
