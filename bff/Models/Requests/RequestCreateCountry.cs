using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bff.Models.Requests
{
    public class RequestCreateCountry
    {
        /// <summary>
        /// Country Name
        /// </summary>
        public required string Name { get; set; }
    }
}