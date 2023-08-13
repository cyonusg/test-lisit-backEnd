using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bff.Models.Requests
{
    public class RequestCreateCommune
    {
        /// <summary>
        /// Commune Name
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Region parent
        /// </summary>
        public required string RegionId { get; set; }
    }
}