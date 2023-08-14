using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using bff.Models;
using bff.Models.Requests;
using bff.Models.Responses;

namespace bff.Services
{
    public interface ISocialHelpService {
        Task<ResponseGetSocialHelp> FindOne(string id, Dictionary<string, string> header);
        Task<ResponseGetSocialHelps> FindAll(Dictionary<string, string> header);
        Task<ResponseMicroServices> Create(RequestCreateSocialHelp socialHelp, Dictionary<string, string> header);
        Task<ResponseMicroServices> Delete(string id, Dictionary<string, string> header);
        Task<ResponseMicroServices> CreateBeneficiaries(RequestCreateBeneficiary beneficiary, Dictionary<string, string> header);
        Task<ResponseMicroServices> DeleteBeneficiaries(RequestCreateBeneficiary beneficiary, Dictionary<string, string> header);
    }
    public class SocialHelpService: ISocialHelpService
    {
        private static readonly string BaseUrl = "http://social-help-api:80/";
        private static readonly string SocialHelp = "socialHelp";

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        public SocialHelpService(HttpClient httpClientFactory)
        {
            _httpClient = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = false };
        }


            public async Task<ResponseGetSocialHelp> FindOne(string id, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{SocialHelp}/{id}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage response = await client.GetAsync(requestUri);
                string content = await response.Content.ReadAsStringAsync();

                ResponseGetSocialHelp data = JsonSerializer.Deserialize<ResponseGetSocialHelp>(content, _options);

                return data ?? new ResponseGetSocialHelp { };
            }
        
            public async Task<ResponseGetSocialHelps> FindAll(Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{SocialHelp}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage response = await client.GetAsync(requestUri);
                string content = await response.Content.ReadAsStringAsync();

                ResponseGetSocialHelps data = JsonSerializer.Deserialize<ResponseGetSocialHelps>(content, _options);

                return data ?? new ResponseGetSocialHelps { };
            }
        
            public async Task<ResponseMicroServices> Create(RequestCreateSocialHelp socialHelp, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{SocialHelp}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);

                var payload = JsonSerializer.Serialize(socialHelp);
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(requestUri, content);
                string reponseJson = await response.Content.ReadAsStringAsync();

                ResponseMicroServices data = JsonSerializer.Deserialize<ResponseMicroServices>(reponseJson, _options);

                return data ?? new ResponseMicroServices { };
            }
        
            public async Task<ResponseMicroServices> CreateBeneficiaries(RequestCreateBeneficiary beneficiary, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{SocialHelp}/{beneficiary.SocialHelpId}/{beneficiary.UserId}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);

                var payload = JsonSerializer.Serialize(beneficiary);
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(requestUri, content);
                string reponseJson = await response.Content.ReadAsStringAsync();

                ResponseMicroServices data = JsonSerializer.Deserialize<ResponseMicroServices>(reponseJson, _options);

                return data ?? new ResponseMicroServices { };
            }
            public async Task<ResponseMicroServices> DeleteBeneficiaries(RequestCreateBeneficiary beneficiary, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{SocialHelp}/{beneficiary.SocialHelpId}/{beneficiary.UserId}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);

                HttpResponseMessage response = await client.DeleteAsync(requestUri);
                string reponseJson = await response.Content.ReadAsStringAsync();

                ResponseMicroServices data = JsonSerializer.Deserialize<ResponseMicroServices>(reponseJson, _options);

                return data ?? new ResponseMicroServices { };
            }
        
            //CountryUptate

            public async Task<ResponseMicroServices> Delete(string id, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{SocialHelp}/{id}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);

                HttpResponseMessage response = await client.DeleteAsync(requestUri);
                string reponseJson = await response.Content.ReadAsStringAsync();

                ResponseMicroServices data = JsonSerializer.Deserialize<ResponseMicroServices>(reponseJson, _options);

                return data ?? new ResponseMicroServices { };
            }
    }
}