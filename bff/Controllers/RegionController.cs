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
    public class RegionController : ControllerBase
    {

        readonly ILocationsService _locationsService;
        readonly IUsersService _usersService;

        
        public RegionController(ILocationsService locationService, IUsersService users) {
            _locationsService = locationService;
            _usersService = users;

        }

        [HttpGet]
        public async Task<ResponseGetRegions> GetAll()
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseGetRegions countries = await _locationsService.RegionFindAll(header);

            RequestLogging action = new() {
                Type = "Get",
                Description = "Request Get all Region ",
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return countries;
        }

        [HttpGet("{id}")]
        public async Task<ResponseGetRegion> GetById(string id)
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseGetRegion Region = await _locationsService.RegionFindOne(id, header);

            RequestLogging action = new() {
                Type = "Get",
                Description = "Request Get one Region " + id,
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return Region;
        }

        [HttpPost]
        public async Task<ResponseMicroServices> Create(RequestCreateRegion model)
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseMicroServices response = await _locationsService.RegionCreate(model, header);

            RequestLogging action = new() {
                Type = "create",
                Description = "Request create Region ",
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return response;
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRequest model)
        {
            await _userService.Update(id, model);
            return Ok(new { message = "Region updated" });
        }*/

        [HttpDelete("{id}")]
        public async Task<ResponseMicroServices> Delete(string id)
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseMicroServices response = await _locationsService.RegionDelete(id, header);

            RequestLogging action = new() {
                Type = "delete",
                Description = "Request delete Region ",
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return response;
        }
    }
}