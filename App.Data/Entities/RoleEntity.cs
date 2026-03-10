using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace App.Data.Entities
{
    public class RoleEntity : EntityBase
    {
        public string Name { get; set; } = null!;

      

        public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
    }
}
