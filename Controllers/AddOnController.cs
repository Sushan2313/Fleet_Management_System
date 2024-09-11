using FM.Modles;
using Fleetmanagement_new.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace Fleetmanagement_new.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AddOnController : ControllerBase
    {
        private readonly IAddOnService service;

        public AddOnController(IAddOnService addOnService)
        {
            service = addOnService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddOn>>> GetAllAddOns()
        {
            var addOns = await service.GetAllAddOnsAsync();
            return Ok(addOns);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddOn>> GetAddOnById(long id)
        {
            var addOn = await service.GetAddOnByIdAsync(id);
            if (addOn == null) return NotFound();
            return Ok(addOn);
        }

        [HttpPost]
        public async Task<ActionResult> AddAddOn(AddOn addOn)
        {
            await service.AddAddOnAsync(addOn);
            return CreatedAtAction(nameof(GetAddOnById), new { id = addOn.AddonId }, addOn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddOn(long id, AddOn addOn)
        {
            if (id != addOn.AddonId) return BadRequest();
            await service.UpdateAddOnAsync(addOn);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddOn(long id)
        {
            await service.DeleteAddOnAsync(id);
            return NoContent();
        }
    }
}
