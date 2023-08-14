using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using bff.Entities;

namespace bff.Models.Responses
{
    public class ResponseGetUsers: ResponseMicroServices
    {
        [JsonPropertyName("data")]
        public IList<User>? Data { get; set; }
    }
}