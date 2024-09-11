using Fleetmanagement_new.Services;
using FM.Modles;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fleetmanagement_new.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class CarController : ControllerBase
    {
        private readonly ICarService _service;

        public CarController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            var cars = await _service.GetAllCarsAsync();
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(long id)
        {
            var car = await _service.GetCarByIdAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(Car car)
        {
            if (car == null)
            {
                return BadRequest();
            }

            try
            {
                var createdCar = await _service.CreateCarAsync(car);
                return CreatedAtAction(nameof(GetCar), new { id = createdCar.CarId }, createdCar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(long id, Car car)
        {
            if (id != car.CarId)
            {
                return BadRequest();
            }

            var updatedCar = await _service.UpdateCarAsync(id, car);
            if (updatedCar == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpGet("bytypeandhub")]
        public async Task<ActionResult<IEnumerable<Car>>> GetCarsByTypeAndHub([FromQuery] long carTypeId, [FromQuery] long hubId)
        {
            var cars = await _service.GetCarsByTypeAndHubAsync(carTypeId, hubId);
            if (!cars.Any())
            {
                return NotFound();
            }
            return Ok(cars);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(long id)
        {
            var result = await _service.DeleteCarAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
