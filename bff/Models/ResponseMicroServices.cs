using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.OpenApi.Any;

namespace bff.Models
{
    public class ResponseMicroServices
    {
        [JsonPropertyName("message")]
        public string? Message {get; set;}
    }

}