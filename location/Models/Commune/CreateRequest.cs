using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace location.Models.Commune
{
    public class CreateRequest
    {
        /// <summary>
        /// Region Name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Region Id
        /// </summary>
        public required string RegionId { get; set; }
    }
}