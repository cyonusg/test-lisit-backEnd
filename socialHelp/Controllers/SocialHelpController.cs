using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using socialHelp.Entities;
using socialHelp.Models.SocialHelp;
using socialHelp.Services;

namespace socialHelp.Controllers
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
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<SocialHelp> socialHelps = await _socialHelpService.GetAll();
            return Ok(socialHelps);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            SocialHelp socialHelp = await _socialHelpService.GetById(id);
            return Ok(socialHelp);
        }

        [HttpPost("{socialHelpId}/{userId}")]
        public async Task<IActionResult> CreateBeneficiaryToSocialHelp(string socialHelpId, string userId)
        {
            Models.Beneficiary.RequestCreate model = new() {
                SocialHelpId = socialHelpId,
                UserId = userId
            };
            await _socialHelpService.CreateBeneficiaries(model);
            return Ok(new { message = "Beneficiary added" });
        }

        [HttpDelete("{socialHelpId}/{userId}")]
        public async Task<IActionResult> DeleteBeneficiaryToSocialHelp(string socialHelpId, string userId)
        {
            await _socialHelpService.DeleteBeneficiaries(socialHelpId, userId);
            return Ok(new { message = "Beneficiary removed" });
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequestCreate model)
        {
            await _socialHelpService.Create(model);
            return Ok(new { message = "Social Helper created" });
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRequest model)
        {
            await _userService.Update(id, model);
            return Ok(new { message = "Country updated" });
        }*/

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _socialHelpService.Delete(id);
            return Ok(new { message = "Country deleted" });
        }
    }
}