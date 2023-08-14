using System.Text.Json.Serialization;
using bff.Entities;

namespace bff.Models.Responses
{
    public class ResponseGetSocialHelp: ResponseMicroServices
    {
        [JsonPropertyName("data")]
        public SocialHelp? Data {get; set;}
    }
}