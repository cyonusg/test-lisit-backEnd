using location.Models.Country;
using location.Entities;
using location.Services;
using Microsoft.AspNetCore.Mvc;

namespace location.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase {

        readonly ICountryService _countryService;
        
        public CountryController(ICountryService countryService) {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Country> countries = await _countryService.GetAll();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            Country country = await _countryService.GetById(id);
            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRequest model)
        {
            await _countryService.Create(model);
            return Ok(new { message = "Country created" });
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
            await _countryService.Delete(id);
            return Ok(new { message = "Country deleted" });
        }
    }
}