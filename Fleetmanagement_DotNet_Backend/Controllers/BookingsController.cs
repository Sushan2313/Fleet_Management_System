using Fleetmanagement_new.Services; 
using FM.Modles;
using FM.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleetmanagement_new.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings = await _bookingService.GetBookingsAsync();
            return Ok(bookings);
        }

        // GET: api/Bookings/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(long id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        // GET: api/Bookings/email/{email}
        [HttpGet("email/{email}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingsByEmail(string email)
        {
            var bookings = await _bookingService.GetBookingsByEmailAsync(email);
            if (bookings == null || !bookings.Any())
            {
                return NotFound();
            }
            return Ok(bookings);
        }

        // POST: api/Bookings
        [HttpPost]
        public async Task<ActionResult<Booking>> CreateBooking(Booking booking)
        {
            var createdBooking = await _bookingService.CreateBookingAsync(booking);
            return CreatedAtAction(nameof(GetBooking), new { id = createdBooking.BookingId }, createdBooking);
        }

        // PUT: api/Bookings/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(long id, Booking booking)
        {
            var success = await _bookingService.UpdateBookingAsync(id, booking);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Bookings/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(long id)
        {
            var success = await _bookingService.DeleteBookingAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
