using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using FM.Repositories;
using FM.Modles;
using Microsoft.AspNetCore.Cors;

namespace Fleet_Sam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BookingDetailController : ControllerBase
    {
        private readonly FMContext _context;

        public BookingDetailController(FMContext context)
        {
            _context = context;
        }

        // GET: api/BookingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDetail>>> GetBookingDetails()
        {
            return await _context.BookingDetails.Include(bd => bd.Booking).ToListAsync();
        }

        // GET: api/BookingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDetail>> GetBookingDetail(long id)
        {
            var bookingDetail = await _context.BookingDetails
                .Include(bd => bd.Booking)
                .FirstOrDefaultAsync(bd => bd.BookingDetailId == id);

            if (bookingDetail == null)
            {
                return NotFound();
            }

            return bookingDetail;
        }

        // POST: api/BookingDetails
        [HttpPost]
        public async Task<ActionResult<BookingDetail>> PostBookingDetail(BookingDetail bookingDetail)
        {
            _context.BookingDetails.Add(bookingDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookingDetail), new { id = bookingDetail.BookingDetailId }, bookingDetail);
        }

        // PUT: api/BookingDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingDetail(long id, BookingDetail bookingDetail)
        {
            if (id != bookingDetail.BookingDetailId)
            {
                return BadRequest();
            }

            _context.Entry(bookingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/BookingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingDetail(long id)
        {
            var bookingDetail = await _context.BookingDetails.FindAsync(id);
            if (bookingDetail == null)
            {
                return NotFound();
            }

            _context.BookingDetails.Remove(bookingDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingDetailExists(long id)
        {
            return _context.BookingDetails.Any(e => e.BookingDetailId == id);
        }
    }
}
