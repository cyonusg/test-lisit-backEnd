using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bff.Models;

namespace bff.Services
{
    public interface IUsersService {
        /*Task Create(CreateRequest model);
        Task<User> Login(string email, string password);
        Task<User> FindOne(string email);*/

        Task<HttpResponseMessage> UserAction (string email, string dateAction, Dictionary<string, string> header);
    }
    public class UsersService : IUsersService
    {
        private static readonly string BaseUrl = "http://localhost:5421";
        private static readonly string Users = "users";
        private static readonly string Auth = "auth";
        private readonly HttpClient _httpClient;
        public UsersService(HttpClient httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }
        public async Task<HttpResponseMessage> UserAction(string id, string dateAction, Dictionary<string, string> header) {
            string requestUri = $"{BaseUrl}/{Users}/history/{id}/{dateAction}";
            HttpClientHandler handler = new HttpClientHandler
            {
                PreAuthenticate = true,
                UseDefaultCredentials = false,
                //Proxy = proxy
            };

            HttpClient client = _httpClient;

            // Configura la URL base del servicio Users
            client.BaseAddress = new Uri(BaseUrl);

            // Realiza la llamada GET al servicio Users
            HttpResponseMessage response = await client.GetAsync(requestUri);
            //ResponseMicroServices response = await _httpClientFactory.GetAsync<ResponseMicroServices>(requestUri, false, query, header);
            return response;
        }
    }
}