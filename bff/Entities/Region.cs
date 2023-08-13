using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bff.Entities
{
    public class Region
    {
        /// <summary>
        /// Region Id
        /// </summary>
        /// 
        public required string Id { get; set; }

        /// <summary>
        /// Region Name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// country id owner region
        /// </summary>
        public required string CountryId { get; set; }

        public IList<Commune>? Communes  { get; set; }

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