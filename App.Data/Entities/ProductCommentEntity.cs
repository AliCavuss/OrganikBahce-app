using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    internal class ProductCommentEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public byte StarCount { get; set; }
        public bool IsConfirmed { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
