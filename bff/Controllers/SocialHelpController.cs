using bff.Models;
using bff.Models.Requests;
using bff.Models.Responses;
using bff.Services;
using Microsoft.AspNetCore.Mvc;

namespace bff.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SocialHelpController : ControllerBase
    {
        readonly ISocialHelpService _socialHelpService;
        readonly IUsersService _usersService;

        
        public SocialHelpController(ISocialHelpService socialHelpService, IUsersService users) {
            _socialHelpService = socialHelpService;
            _usersService = users;
        }


        [HttpGet]
        public async Task<ResponseGetSocialHelps> GetAll()
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseGetSocialHelps socialHelps = await _socialHelpService.FindAll(header);

            RequestLogging action = new() {
                Type = "Get",
                Description = "Request Get all Social helps ",
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return socialHelps;
        }

        [HttpGet("{id}")]
        public async Task<ResponseGetSocialHelp> GetById(string id)
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseGetSocialHelp socialHelp = await _socialHelpService.FindOne(id, header);


            RequestLogging action = new() {
                Type = "Get",
                Description = "Request Get one Social helps " + id,
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return socialHelp;
        }

        [HttpPost("{socialHelpId}/{userId}")]
        public async Task<ResponseMicroServices> CreateBeneficiaryToSocialHelp(string socialHelpId, string userId)
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            RequestCreateBeneficiary model = new() {
                SocialHelpId = socialHelpId,
                UserId = userId
            };
            ResponseMicroServices response = await _socialHelpService.CreateBeneficiaries(model, header);


            RequestLogging action = new() {
                Type = "create",
                Description = "Request create beneficiaries  Social helps " + model.SocialHelpId,
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return response;
        }

        [HttpDelete("{socialHelpId}/{userId}")]
        public async Task<ResponseMicroServices> DeleteBeneficiaryToSocialHelp(string socialHelpId, string userId)
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            RequestCreateBeneficiary model = new() {
                SocialHelpId = socialHelpId,
                UserId = userId
            };
            ResponseMicroServices response = await _socialHelpService.DeleteBeneficiaries(model, header);
                RequestLogging action = new() {
                Type = "delete",
                Description = "Request Delete beneficiaries  Social helps " + model.SocialHelpId,
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return response;
        }

        [HttpPost]
        public async Task<ResponseMicroServices> Create(RequestCreateSocialHelp model)
        {
            Dictionary<string, string> header = new Dictionary<string, string>{
                { "User-Agent", "HttpClientExample" },
                { "Accept", "application/json" },
                { "Authorization", "Bearer YOUR_JWT_TOKEN" }  // Reemplaza con tu token JWT
            };
            ResponseMicroServices response = await _socialHelpService.Create(model, header);

            RequestLogging action = new() {
                Type = "create",
                Description = "Request create Social helps ",
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
            ResponseMicroServices response = await _socialHelpService.Delete(id, header);

            
            RequestLogging action = new() {
                Type = "delete",
                Description = "Request delete Social helps" + id,
                UserId = "ssss-sssss-ssss-"
            };
            await _usersService.CreateUserAction(action, header);
            return response;
        }
    }
}