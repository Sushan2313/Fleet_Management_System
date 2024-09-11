using FM.Modles;

using Microsoft.AspNetCore.Mvc;
using Fleetmanagement_new.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace Fleetmanagement_new.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class CityController : ControllerBase
    {
        public readonly ICityService service;
        public CityController(ICityService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            var cities = await service.GetAllCitiesAsync();
            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity(long id)
        {
            var city = await service.GetCityById(id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        [HttpPost]
        public async Task<ActionResult<City>> PostCity(City city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            var createdCity = await service.PostCity(city);
            return CreatedAtAction(nameof(GetCity), new { id = createdCity.CityId }, createdCity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCity(long id, City city)
        {
            if (id != city.CityId)
            {
                return BadRequest();
            }

            var updatedCity = await service.PutCity(id, city);
            if (updatedCity == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(long id)
        {
            var result = await service.DeleteCity(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
