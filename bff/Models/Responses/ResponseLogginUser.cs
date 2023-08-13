using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using bff.Entities;

namespace bff.Models.Responses
{
    public class ResponseLogginUser : ResponseMicroServices
    {    
        [JsonPropertyName("data")]
        public IList<LoggingActions>? Data {get; set;}
    }
}