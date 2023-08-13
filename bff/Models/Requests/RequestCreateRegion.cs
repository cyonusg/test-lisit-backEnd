using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bff.Models.Requests
{
    public class RequestCreateRegion
    {
        /// <summary>
        /// Region Name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Country Parent
        /// </summary>
        public required string CountryId { get; set; }
    }
}