using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bff.Models.Requests
{
    public class RequestLogin
    {
        /// <summary>
        /// User email to login
        /// </summary>
        public required string Email { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        public required string Password { get; set; }
    }
}