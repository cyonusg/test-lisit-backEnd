using System.Text;
using System.Text.Json;
using bff.Models;
using bff.Models.Requests;
using bff.Models.Responses;

namespace bff.Services
{
    public interface ILocationsService {
        Task<ResponseGetCountry> CountryFindOne(string id, Dictionary<string, string> header);
        Task<ResponseGetCountries> CountryFindAll(Dictionary<string, string> header);
        Task<ResponseMicroServices> CountryCreate(RequestCreateCountry location, Dictionary<string, string> header);
        Task<ResponseMicroServices> CountryDelete(string id, Dictionary<string, string> header);
        Task<ResponseGetRegion> RegionFindOne(string id, Dictionary<string, string> header);
        Task<ResponseGetRegions> RegionFindAll(Dictionary<string, string> header);
        Task<ResponseMicroServices> RegionCreate(RequestCreateRegion location, Dictionary<string, string> header);
        Task<ResponseMicroServices> RegionDelete(string id, Dictionary<string, string> header);
        Task<ResponseGetCommune> CommuneFindOne(string id, Dictionary<string, string> header);
        Task<ResponseGetCommunes> CommuneFindAll(Dictionary<string, string> header);
        Task<ResponseMicroServices> CommuneCreate(RequestCreateCommune location, Dictionary<string, string> header);
        Task<ResponseMicroServices> CommuneDelete(string id, Dictionary<string, string> header);
    }
    public class LocationsService : ILocationsService
    {
        private static readonly string BaseUrl = "http://location-api:80/";
        private static readonly string Country = "country";
        private static readonly string Region = "region";
        private static readonly string Commune = "Commune";

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        public LocationsService(HttpClient httpClientFactory)
        {
            _httpClient = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = false };
        }
        #region Country
            public async Task<ResponseGetCountry> CountryFindOne(string id, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{Country}/{id}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage response = await client.GetAsync(requestUri);
                string content = await response.Content.ReadAsStringAsync();

                ResponseGetCountry data = JsonSerializer.Deserialize<ResponseGetCountry>(content, _options);

                return data ?? new ResponseGetCountry { };
            }
        
            public async Task<ResponseGetCountries> CountryFindAll(Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{Country}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage response = await client.GetAsync(requestUri);
                string content = await response.Content.ReadAsStringAsync();

                ResponseGetCountries data = JsonSerializer.Deserialize<ResponseGetCountries>(content, _options);

                return data ?? new ResponseGetCountries { };
            }
        
            public async Task<ResponseMicroServices> CountryCreate(RequestCreateCountry location, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{Country}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);

                var payload = JsonSerializer.Serialize(location);
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(requestUri, content);
                string reponseJson = await response.Content.ReadAsStringAsync();

                ResponseMicroServices data = JsonSerializer.Deserialize<ResponseMicroServices>(reponseJson, _options);

                return data ?? new ResponseMicroServices { };
            }
        
            //CountryUptate

            public async Task<ResponseMicroServices> CountryDelete(string id, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{Country}/{id}";
                
                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);

                HttpResponseMessage response = await client.DeleteAsync(requestUri);
                string reponseJson = await response.Content.ReadAsStringAsync();

                ResponseMicroServices data = JsonSerializer.Deserialize<ResponseMicroServices>(reponseJson, _options);

                return data ?? new ResponseMicroServices { };
            }
        #endregion
        
        #region Region
            public async Task<ResponseGetRegion> RegionFindOne(string id, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{Region}/{id}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage response = await client.GetAsync(requestUri);
                string content = await response.Content.ReadAsStringAsync();

                ResponseGetRegion data = JsonSerializer.Deserialize<ResponseGetRegion>(content, _options);

                return data ?? new ResponseGetRegion { };
            }
        
            public async Task<ResponseGetRegions> RegionFindAll(Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{Region}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage response = await client.GetAsync(requestUri);
                string content = await response.Content.ReadAsStringAsync();

                ResponseGetRegions data = JsonSerializer.Deserialize<ResponseGetRegions>(content, _options);

                return data ?? new ResponseGetRegions { };
            }
        
        
            public async Task<ResponseMicroServices> RegionCreate(RequestCreateRegion location, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{Country}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);

                var payload = JsonSerializer.Serialize(location);
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(requestUri, content);
                string reponseJson = await response.Content.ReadAsStringAsync();

                ResponseMicroServices data = JsonSerializer.Deserialize<ResponseMicroServices>(reponseJson, _options);

                return data ?? new ResponseMicroServices { };
            }
        
            //Country Uptate

            public async Task<ResponseMicroServices> RegionDelete(string id, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{Region}/{id}";
                
                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);

                HttpResponseMessage response = await client.DeleteAsync(requestUri);
                string reponseJson = await response.Content.ReadAsStringAsync();

                ResponseMicroServices data = JsonSerializer.Deserialize<ResponseMicroServices>(reponseJson, _options);

                return data ?? new ResponseMicroServices { };
            }
        #endregion

        #region Commune
            public async Task<ResponseGetCommune> CommuneFindOne(string id, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{Commune}/{id}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage response = await client.GetAsync(requestUri);
                string content = await response.Content.ReadAsStringAsync();

                ResponseGetCommune data = JsonSerializer.Deserialize<ResponseGetCommune>(content, _options);

                return data ?? new ResponseGetCommune { };
            }
        
            public async Task<ResponseGetCommunes> CommuneFindAll(Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{Commune}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);
                HttpResponseMessage response = await client.GetAsync(requestUri);
                string content = await response.Content.ReadAsStringAsync();

                ResponseGetCommunes data = JsonSerializer.Deserialize<ResponseGetCommunes>(content, _options);

                return data ?? new ResponseGetCommunes { };
            }
        
        
            public async Task<ResponseMicroServices> CommuneCreate(RequestCreateCommune location, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{Country}";

                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);

                var payload = JsonSerializer.Serialize(location);
                HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(requestUri, content);
                string reponseJson = await response.Content.ReadAsStringAsync();

                ResponseMicroServices data = JsonSerializer.Deserialize<ResponseMicroServices>(reponseJson, _options);

                return data ?? new ResponseMicroServices { };
            }
        
            //Comune update
            public async Task<ResponseMicroServices> CommuneDelete(string id, Dictionary<string, string> header) {
                string requestUri = $"{BaseUrl}{Commune}/{id}";
                
                HttpClient client = _httpClient;
                client.BaseAddress = new Uri(BaseUrl);

                HttpResponseMessage response = await client.DeleteAsync(requestUri);
                string reponseJson = await response.Content.ReadAsStringAsync();

                ResponseMicroServices data = JsonSerializer.Deserialize<ResponseMicroServices>(reponseJson, _options);

                return data ?? new ResponseMicroServices { };
            }
        #endregion
    }
}