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
    public class CountryController : ControllerBase
    {

        readonly ILocationsService _locationsService;
        readonly IUsersService _usersService;

        
        public CountryController(ILocationsService locationService, IUsersService users) {
            _locationsService = locationService;
            _usersService = users;

        }

        [HttpGet]
        public async Task<ResponseGetCountries> GetAll()
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseGetCountries countries = await _locationsService.CountryFindAll(header);

            RequestLogging action = new() {
                Type = "Get",
                Description = "Request Get all Country ",
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return countries;
        }

        [HttpGet("{id}")]
        public async Task<ResponseGetCountry> GetById(string id)
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseGetCountry country = await _locationsService.CountryFindOne(id, header);

            RequestLogging action = new() {
                Type = "Get",
                Description = "Request Get one Country " + id,
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return country;
        }

        [HttpPost]
        public async Task<ResponseMicroServices> Create(RequestCreateCountry model)
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseMicroServices response = await _locationsService.CountryCreate(model, header);

            RequestLogging action = new() {
                Type = "create",
                Description = "Request create Country ",
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return response;
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRequest model)
        {
            await _userService.Update(id, model);
            return Ok(new { message = "Country updated" });
        }*/

        [HttpDelete("{id}")]
        public async Task<ResponseMicroServices> Delete(string id)
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseMicroServices response = await _locationsService.CountryDelete(id, header);

            RequestLogging action = new() {
                Type = "delete",
                Description = "Request delete Country ",
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return response;
        }
    }
}
