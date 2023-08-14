using System.Text.Json.Serialization;
using bff.Entities;

namespace bff.Models.Responses
{
    public class ResponseGetSocialHelps: ResponseMicroServices
    {
        [JsonPropertyName("data")]
        public IList<SocialHelp>? Data {get; set;}
    }
}