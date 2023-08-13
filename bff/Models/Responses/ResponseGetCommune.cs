using System.Text.Json.Serialization;
using bff.Entities;

namespace bff.Models.Responses
{
    public class ResponseGetCommune: ResponseMicroServices
    {
        [JsonPropertyName("data")]
        public Commune? Data { get; set; }
    }
}