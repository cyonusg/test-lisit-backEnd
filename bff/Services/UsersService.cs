using System.Text;
using System.Text.Json;
using bff.Models;
using bff.Models.Requests;
using bff.Models.Responses;

namespace bff.Services
{
    public interface IUsersService
    {
        Task<ResponseLogginUser> GetUserAction(string email, string dateAction, Dictionary<string, string> header);
        Task<ResponseGetUser> FindOne(string email, Dictionary<string, string> header);

        Task<ResponseMicroServices> Create(RequestCreateUser user, Dictionary<string, string> header);
        Task<ResponseMicroServices> Delete(string email, Dictionary<string, string> header);
        Task<ResponseMicroServices> Login(RequestLogin request, Dictionary<string, string> header);
    }
    public class UsersService : IUsersService
    {
        private static readonly string BaseUrl = "https://localhost:7146/";
        private static readonly string Users = "users";
        private static readonly string Auth = "auth";

        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;
        public UsersService(HttpClient httpClientFactory)
        {
            _httpClient = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = false };
        }
        public async Task<ResponseMicroServices> Login(RequestLogin request, Dictionary<string, string> header) {
            //cambiar esto es un post
            string requestUri = $"{BaseUrl}{Auth}";

            HttpClient client = _httpClient;
            client.BaseAddress = new Uri(BaseUrl);

            var payload = JsonSerializer.Serialize(new { email = request.Email, password = request.Password  });
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(requestUri, content);
            string reponseJson = await response.Content.ReadAsStringAsync();
            if(content == null) return new ResponseMicroServices { };

            ResponseMicroServices data = JsonSerializer.Deserialize<ResponseMicroServices>(reponseJson, _options);

            return data ?? new ResponseMicroServices { };
        }
        public async Task<ResponseGetUser> FindOne(string email, Dictionary<string, string> header) {
            string requestUri = $"{BaseUrl}{Users}/{email}";

            HttpClient client = _httpClient;
            client.BaseAddress = new Uri(BaseUrl);
            HttpResponseMessage response = await client.GetAsync(requestUri);
            string content = await response.Content.ReadAsStringAsync();

            ResponseGetUser data = JsonSerializer.Deserialize<ResponseGetUser>(content, _options);

            return data ?? new ResponseGetUser { };
        }
        public async Task<ResponseLogginUser> GetUserAction(string id, string dateAction, Dictionary<string, string> header)
        {
            string requestUri = $"{BaseUrl}{Users}/history/{id}/{dateAction}";

            HttpClient client = _httpClient;
            client.BaseAddress = new Uri(BaseUrl);
            HttpResponseMessage response = await client.GetAsync(requestUri);
            string content = await response.Content.ReadAsStringAsync();

            if(string.IsNullOrEmpty(content)) return new ResponseLogginUser { };

            ResponseLogginUser data = JsonSerializer.Deserialize<ResponseLogginUser>(content, _options);

            return data ?? new ResponseLogginUser { };
        }
        public async Task<ResponseMicroServices> Create(RequestCreateUser user, Dictionary<string, string> header){
            string requestUri = $"{BaseUrl}{Users}";

            HttpClient client = _httpClient;
            client.BaseAddress = new Uri(BaseUrl);

            var payload = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(requestUri, content);
            string reponseJson = await response.Content.ReadAsStringAsync();

            ResponseMicroServices data = JsonSerializer.Deserialize<ResponseMicroServices>(reponseJson, _options);

            return data ?? new ResponseMicroServices { };
        }
        //update
        public async Task<ResponseMicroServices> Delete(string email, Dictionary<string, string> header){
            string requestUri = $"{BaseUrl}{Users}/{email}";
            
            HttpClient client = _httpClient;
            client.BaseAddress = new Uri(BaseUrl);

            HttpResponseMessage response = await client.DeleteAsync(requestUri);
            string reponseJson = await response.Content.ReadAsStringAsync();

            ResponseMicroServices data = JsonSerializer.Deserialize<ResponseMicroServices>(reponseJson, _options);

            return data ?? new ResponseMicroServices { };
        }
    }
}