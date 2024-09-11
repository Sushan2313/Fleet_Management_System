using Fleetmanagement_new.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using FM.Modles;
using Microsoft.AspNetCore.Cors;
namespace Fleetmanagement_new.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class HubController : ControllerBase
    {
        private readonly IHubService _service;

        public HubController(IHubService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hub>>> GetHubs()
        {
            var hubs = await _service.GetAllHubsAsync();
            return Ok(hubs);
        }

        [HttpGet("{city}")]
        public async Task<ActionResult<IEnumerable<Hub>>> GetHub(String city)
        {
            var hub = await _service.GetHubByCity(city);
            if (hub == null)
            {
                return NotFound();
            }
            return Ok(hub);
        }

        [HttpPost]
        public async Task<ActionResult<Hub>> PostHub(Hub hub)
        {
            if (hub == null)
            {
                return BadRequest();
            }

            try
            {
                var createdHub = await _service.PostHub(hub);
                return CreatedAtAction(nameof(GetHub), new { id = createdHub.HubId }, createdHub);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHub(long id, Hub hub)
        {
            if (id != hub.HubId)
            {
                return BadRequest();
            }

            var updatedHub = await _service.PutHub(id, hub);
            if (updatedHub == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHub(long id)
        {
            var result = await _service.DeleteHub(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
