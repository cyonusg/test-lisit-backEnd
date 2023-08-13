using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bff.Entities
{
    public class Country
    {
        /// <summary>
        /// Country Id
        /// </summary>
        /// 
        public required string Id { get; set; }

        /// <summary>
        /// Name Country
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Region country owner
        /// </summary>
        public IList<Region>? Regions  { get; set; }
        /// <summary>
        /// Create Date
        /// </summary>

        public required DateTime CreatedAt { get; set; }

        /// <summary>
        /// Update Date
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Delete Date
        /// </summary>
        public DateTime? DeletedAt { get; set; }
    }
}