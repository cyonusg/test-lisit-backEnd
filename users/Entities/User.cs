using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace users.Entities
{
    public class User
    {
        /// <summary>
        /// User Id
        /// </summary>
        /// 
        public required string Id { get; set; }
        /// <summary>
        /// User first name
        /// </summary>

        public required string Name { get; set; }
        /// <summary>
        /// User last name
        /// </summary>

        public required string LastName { get; set; }
        /// <summary>
        /// User email
        /// </summary>

        public required string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [JsonIgnore]
        public string? PasswordHash { get; set; }

        /// <summary>
        /// User Role
        /// </summary>

        public Role Role { get; set; }

        /// <summary>
        /// Commune Id
        /// </summary>

        public required string CommuneId { get; set; }

    }
}