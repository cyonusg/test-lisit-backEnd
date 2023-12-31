using System.Text.Json.Serialization;
using bff.Entities;

namespace bff.Models.Responses
{
    public class ResponseGetRegion: ResponseMicroServices
    {
        [JsonPropertyName("data")]
        public Region? Data { get; set; }
    }
}