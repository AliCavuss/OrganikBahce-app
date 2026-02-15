using App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Data.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public DateTime CreatedAt { get; set; }



        #region ForeignKey

        [JsonIgnore]
        public UserEntity User { get; set; } = null!;

        #endregion
    }

}