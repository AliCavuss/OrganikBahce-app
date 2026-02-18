using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace App.Data.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // 1 Role -> N User
        [JsonIgnore]
        public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
    }
}
