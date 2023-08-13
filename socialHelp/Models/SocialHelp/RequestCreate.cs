using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialHelp.Models.SocialHelp
{
    public class RequestCreate
    {
        
        /// <summary>
        /// Social Help Name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Social Help Description
        /// </summary>
        public required string Description { get; set; }

        /// <summary>
        /// Location parent Type: Region/Commune
        /// </summary>
        public required string LocationType { get; set; }
    
        /// <summary>
        /// Location id parent
        /// </summary>
        public required string LocationId { get; set; }

        /// <summary>
        /// Date Activation social helprs
        /// </summary>
        public required DateTime DateActivation { get; set; }

        /// <summary>
        /// Date Expiration social helprs
        /// </summary>
        public required DateTime DateExpiration { get; set; }
    }
}