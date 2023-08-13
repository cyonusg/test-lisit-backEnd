using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace location.Models.Country
{
    public class CreateRequest
    {
        /// <summary>
        /// Country Name
        /// </summary>
        public required string Name { get; set; }

    }
}