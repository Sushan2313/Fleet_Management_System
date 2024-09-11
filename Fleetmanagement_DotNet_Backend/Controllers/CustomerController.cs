
using Fleets.Services;
using FM.Modles;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fleets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   

    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(long id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(Customer customer)
        {
            await _customerService.AddCustomerAsync(customer);
            //
            //return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
            return CreatedAtAction(nameof(GetCustomer), customer);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(long id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            await _customerService.UpdateCustomerAsync(customer);
            return NoContent();
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetCustomerByEmail(string email)
        {
            var customer = await _customerService.GetCustomerByEmailAsync(email);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet("login/{email}/{password}")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var isValid = await _customerService.ValidateCustomerLoginAsync(email, password);
            if (!isValid)
            {
                return Unauthorized(new { success = false, message = "Invalid login credentials" });
            }
            return Ok(new { success = true });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(long id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}