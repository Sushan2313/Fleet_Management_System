using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FM.Modles;
using Fleetmanagement_new.Services;
using Microsoft.AspNetCore.Cors;
namespace Fleetmanagement_new.Controllers
   
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class StateController : ControllerBase
    {
        private readonly IStateService _service;

        public StateController(IStateService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            var states = await _service.GetAllStatesAsync();
            return Ok(states);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetState(long id)
        {
            var state = await _service.GetStateById(id);
            if (state == null)
            {
                return NotFound();
            }
            return Ok(state);
        }

        [HttpPost]
        public async Task<ActionResult<State>> PostState(State state)
        {
            if (state == null)
            {
                return BadRequest();
            }

            var createdState = await _service.PostState(state);
            return CreatedAtAction(nameof(GetState), new { id = createdState.StateId }, createdState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(long id, State state)
        {
            if (id != state.StateId)
            {
                return BadRequest();
            }

            var updatedState = await _service.PutState(id, state);
            if (updatedState == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(long id)
        {
            var result = await _service.DeleteState(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
