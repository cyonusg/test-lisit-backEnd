using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bff.Models;
using bff.Models.Requests;
using bff.Models.Responses;
using bff.Services;
using Microsoft.AspNetCore.Mvc;

namespace bff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase {

        readonly IUsersService _usersService;
        
        public UsersController(IUsersService users) {
            _usersService = users;
        }

        [HttpGet("history/{id}/{dateAction}")]
        public async Task<ResponseLogginUser> GetUserAction(string id, string dateAction) {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseLogginUser logginActions = await _usersService.GetUserAction(id, dateAction, header);
            return logginActions;
        }

        [HttpGet("{email}")]
        public async Task<ResponseGetUser> FindOne(string email) {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseGetUser user = await _usersService.FindOne(email, header);
            return user;
        }

        [HttpPost]
        public async Task<ResponseMicroServices> Post ( RequestCreateUser Request) {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            return await _usersService.Create(Request, header);
        }

        [HttpPatch]
        public IActionResult patch (string email) {
            return NotFound(new { message = "No scope Test"});
        }

        [HttpDelete("{email}")]
        public async Task<ResponseMicroServices> Delete (string email) {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            return await _usersService.Delete(email, header);
        }
    }
}