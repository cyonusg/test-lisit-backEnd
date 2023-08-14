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
    public class CommuneController : ControllerBase
    {
        readonly ILocationsService _locationsService;
        readonly IUsersService _usersService;

        public CommuneController(ILocationsService locationService, IUsersService users) {
            _locationsService = locationService;
            _usersService = users;
        }


        [HttpGet]
        public async Task<ResponseGetCommunes> GetAll()
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseGetCommunes countries = await _locationsService.CommuneFindAll(header);

            RequestLogging action = new() {
                Type = "Get",
                Description = "Request Get all Commune ",
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return countries;
        }

        [HttpGet("{id}")]
        public async Task<ResponseGetCommune> GetById(string id)
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseGetCommune Commune = await _locationsService.CommuneFindOne(id, header);

            RequestLogging action = new() {
                Type = "Get",
                Description = "Request Get one Commune " + id,
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return Commune;
        }

        [HttpPost]
        public async Task<ResponseMicroServices> Create(RequestCreateCommune model)
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseMicroServices response = await _locationsService.CommuneCreate(model, header);

            RequestLogging action = new() {
                Type = "create",
                Description = "Request create Commune ",
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return response;
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRequest model)
        {
            await _userService.Update(id, model);
            return Ok(new { message = "Commune updated" });
        }*/

        [HttpDelete("{id}")]
        public async Task<ResponseMicroServices> Delete(string id)
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseMicroServices response = await _locationsService.CommuneDelete(id, header);

            RequestLogging action = new() {
                Type = "delete",
                Description = "Request delete Commune ",
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return response;
        }
    }
}