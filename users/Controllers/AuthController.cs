using Microsoft.AspNetCore.Mvc;
using users.Models.auth;
using users.Services;
using Validator = users.Helpers.Validations;
namespace users.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController: ControllerBase {

        readonly IUsersService _usersService;
        
        public AuthController(IUsersService users) {
            _usersService = users;
        }

        [HttpPost]
        public async Task<IActionResult> Post ( LoginRequest Request) {
            if(!Validator.IsValidEmail(Request.Email)) return BadRequest(new { message = "Email invalid"});
            await _usersService.Login(Request.Email, Request.Password);
            return Ok(new { message = "User login", token = "bla bla bla" });
        }

    }
}