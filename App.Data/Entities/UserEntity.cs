using System;
using System.Text.Json.Serialization;

namespace App.Data.Entities
{
    public class UserEntity : EntityBase, IHasEnabled
    {
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;

        // FK: User -> Role
        public int RoleId { get; set; }

        public bool Enabled { get; set; }

  
        public RoleEntity Role { get; set; } = null!;
    }
}
