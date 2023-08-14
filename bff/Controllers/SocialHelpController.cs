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
        
        public SocialHelpController(ISocialHelpService socialHelpService) {
            _socialHelpService = socialHelpService;
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
            return response;
        }
    }
}