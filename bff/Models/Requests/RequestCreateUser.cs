using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace bff.Models.Requests
{
    public class RequestCreateUser
    {
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
        public required string Password { get; set; }

        /// <summary>
        /// User Role
        /// </summary>
        public required string Role { get; set; }

        /// <summary>
        /// Commune Id
        /// </summary>
        public required string CommuneId { get; set; }
    }
}