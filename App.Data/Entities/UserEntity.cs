using System;
using System.Text.Json.Serialization;

namespace App.Data.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // FK: User -> Role
        public int RoleId { get; set; }

        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public RoleEntity Role { get; set; } = null!;
    }
}
