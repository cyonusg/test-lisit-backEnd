using bff.Models;
using bff.Models.Requests;
using bff.Services;
using Microsoft.AspNetCore.Mvc;

namespace bff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController
    {
        readonly IUsersService _usersService;
        
        public AuthController(IUsersService users) {
            _usersService = users;
        }

        [HttpPost]
        public async Task<ResponseMicroServices> Post ( RequestLogin Request) {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseMicroServices response =  await _usersService.Login(Request, header);
            return response;
        }
    }
}
