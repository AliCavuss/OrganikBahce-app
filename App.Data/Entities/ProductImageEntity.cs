using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    internal class ProductImageEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
