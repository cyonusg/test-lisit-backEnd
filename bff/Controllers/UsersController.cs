using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetUserAction(string id, string dateAction) {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            var logginActions = await _usersService.UserAction(id, dateAction, header);
            return Ok(new { message = "Request success", data = logginActions} );
        }
    }
}