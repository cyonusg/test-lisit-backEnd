using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialHelp.Models.Beneficiary
{
    public class RequestCreate
    {
        /// <summary>
        /// Beneficiary Id
        /// </summary>
        public required string UserId { get; set; }

        /// <summary>
        /// Social Help Id
        /// </summary>
        public required string SocialHelpId { get; set; }
    }
}