using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace location.Models.Region
{
    public class CreateRequest
    {
        /// <summary>
        /// Region Name
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Country Id
        /// </summary>
        public required string CountryId { get; set; }
    }
}