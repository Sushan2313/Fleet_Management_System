using FM.Modles;
using Fleetmanagement_new.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace Fleetmanagement_new.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class CarTypeController : ControllerBase
    {
        private readonly ICarTypeService _service;

        public CarTypeController(ICarTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarType>>> GetCarTypes()
        {
            var carTypes = await _service.GetAllCarTypesAsync();
            return Ok(carTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarType>> GetCarType(long id)
        {
            var carType = await _service.GetCarTypeByIdAsync(id);
            if (carType == null)
            {
                return NotFound();
            }
            return Ok(carType);
        }

        [HttpPost]
        public async Task<ActionResult<CarType>> PostCarType(CarType carType)
        {
            if (carType == null)
            {
                return BadRequest();
            }

            try
            {
                var createdCarType = await _service.CreateCarTypeAsync(carType);
                return CreatedAtAction(nameof(GetCarType), new { id = createdCarType.CarTypeId }, createdCarType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarType(long id, CarType carType)
        {
            if (id != carType.CarTypeId)
            {
                return BadRequest();
            }

            var updatedCarType = await _service.UpdateCarTypeAsync(id, carType);
            if (updatedCarType == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarType(long id)
        {
            var result = await _service.DeleteCarTypeAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
