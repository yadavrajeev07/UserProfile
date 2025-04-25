using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using userprofileapp.Services;
using userprofileapp.Models;

namespace userprofileapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        // GET: api/location/countries
        [HttpGet("countries")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _locationService.GetCountriesAsync();
            return Ok(countries);
        }

        // GET: api/location/states/{countryId}
        [HttpGet("states/{countryId}")]
        public async Task<IActionResult> GetStates(string countryId)
        {
            var states = await _locationService.GetStatesByCountryIdAsync(countryId);
            return Ok(states);
        }
    }
}
