using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using users.Entities;
using users.Models.Users;
using users.Services;
using Validator = users.Helpers.Validations;
namespace users.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase {

        readonly IUsersService _usersService;
        
        public UsersController(IUsersService users) {
            _usersService = users;
        }
    
        /*[HttpGet]
        public IEnumerable<WeatherForecast> GetAll()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "holi"
            })
            .ToArray();
        }*/

        [HttpGet("{email}")]
        public async Task<IActionResult> FindOne(string Email) {
            if(!Validator.IsValidEmail(Email)) return BadRequest(new { message = "Email invalid"});
            User user = await _usersService.FindOne(Email);
            return Ok(new { message = "Request success", data = user} );
        }
        [HttpGet("history/{id}/{dateAction}")]
        public async Task<IActionResult> GetUserAction(string id, string dateAction) {
            IEnumerable<LoggingActions> logginActions = await _usersService.UserAction(id, dateAction);
            return Ok(new { message = "Request success", data = logginActions} );
        }

        [HttpPost]
        public async Task<IActionResult> Post ( CreateRequest Request) {
            if(!Validator.IsValidEmail(Request.Email)) return BadRequest(new { message = "Email invalid"});
            await _usersService.Create(Request);
            return Ok(new { message = "User created" });
        }

        [HttpPatch]
        public IActionResult patch (string email) {
            if(!Validator.IsValidEmail(email)) return BadRequest(new { message = "Email invalid"});
            return NotFound(new { message = "No scope Test"});
        }

        [HttpDelete("{email}")]
        public IActionResult Delete (string email) {
            if(!Validator.IsValidEmail(email)) return BadRequest(new { message = "Email invalid"});
            return Ok();
        }
    }
}