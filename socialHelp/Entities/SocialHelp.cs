using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace socialHelp.Entities
{
    public class SocialHelp
    {
        /// <summary>
        /// Social Help Id
        /// </summary>
        /// 
        public required string Id { get; set; }

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
        /// Users access social help
        /// </summary>
        public required  IList<Beneficiary>? Beneficiaries { get; set; }

        /// <summary>
        /// Date Activation social help
        /// </summary>
        
        public required DateTime DateActivation { get; set; }

        /// <summary>
        /// Date Expiration social help
        /// </summary>
        public required DateTime DateExpiration { get; set; }


        /// <summary>
        /// Create Date
        /// </summary>
        public required DateTime CreatedAt { get; set; }

        /// <summary>
        /// Update Date
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Delete Date
        /// </summary>
        public DateTime DeletedAt { get; set; }
    }
}