using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;



namespace App.Data.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; } =string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; }





        #region ForeignKey

        //[ForeignKey(nameof(RoleId))]
        [JsonIgnore]
        public RoleEntity Role { get; set; } = null!;

        #endregion


        
    }
}
