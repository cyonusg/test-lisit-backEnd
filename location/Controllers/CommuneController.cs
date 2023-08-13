using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using location.Entities;
using location.Models.Commune;
using location.Services;
using Microsoft.AspNetCore.Mvc;

namespace location.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommuneController: ControllerBase {

        readonly ICommuneService _communeService;
        
        public CommuneController(ICommuneService communeService) {
            _communeService = communeService;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Commune> communes = await _communeService.GetAll();
            return Ok(communes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Commune commune = await _communeService.GetById(id);
            return Ok(commune);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequest model)
        {
            await _communeService.Create(model);
            return Ok(new { message = "Commune created" });
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
            await _communeService.Delete(id);
            return Ok(new { message = "Commune deleted" });
        }
    }
}