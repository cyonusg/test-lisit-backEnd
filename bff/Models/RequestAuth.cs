using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bff.Models
{
    public class RequestAuth
    {
        /// <summary>
        /// User email
        /// </summary>
        public required string Email { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public required string Password { get; set; }
    }
}