using location.Entities;
using location.Models.Region;
using location.Services;
using Microsoft.AspNetCore.Mvc;

namespace location.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        
        readonly IRegionService _regionService;
        
        public RegionController(IRegionService regionService) {
            _regionService = regionService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Region> regions = await _regionService.GetAll();
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Region region = await _regionService.GetById(id);
            return Ok(region);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequest model)
        {
            await _regionService.Create(model);
            return Ok(new { message = "Region created" });
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateRequest model)
        {
            await _userService.Update(id, model);
            return Ok(new { message = "Region updated" });
        }*/

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _regionService.Delete(id);
            return Ok(new { message = "Region deleted" });
        }
    }
}