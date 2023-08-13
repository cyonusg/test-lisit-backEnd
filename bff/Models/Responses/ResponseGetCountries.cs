using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bff.Entities;

namespace bff.Models.Responses
{
    public class ResponseGetCountries : ResponseMicroServices
    {
        public IList<Country>? Data { get; set; }
    }
}