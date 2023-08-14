using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace bff.Entities
{
    public class User
    {
        /// <summary>
        /// User Id
        /// </summary>
        ///
        [JsonPropertyName("id")]
        public required string Id { get; set; }
        /// <summary>
        /// User first name
        /// </summary>
        [JsonPropertyName("name")]

        public required string Name { get; set; }
        /// <summary>
        /// User last name
        /// </summary>
        [JsonPropertyName("lastName")]

        public required string LastName { get; set; }
        /// <summary>
        /// User email
        /// </summary>
        /// 
        [JsonPropertyName("email")]

        public required string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [JsonPropertyName("password")]

        public string? Password { get; set; }

        /// <summary>
        /// User Role
        /// </summary>
        [JsonPropertyName("role")]

        public string? Role { get; set; }

        /// <summary>
        /// Commune Id
        /// </summary>
        /// 
        [JsonPropertyName("communeId")]
        public required string CommuneId { get; set; }

    }
}