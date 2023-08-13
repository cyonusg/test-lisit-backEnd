using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace location.Entities
{
    public class Commune
    {
        /// <summary>
        /// Commune Id
        /// </summary>
        /// 
        public required string Id { get; set; }

        /// <summary>
        /// Commune Name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Region id owner country
        /// </summary>
        public required string RegionId { get; set; }

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