using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using FM.Repositories;
using FM.Modles;

namespace FM.Services
{
    public class BookingDetailService : IBookingDetailService
    {
        private readonly FMContext _context;

        public BookingDetailService(FMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookingDetail>> GetBookingDetailsAsync()
        {
            return await _context.BookingDetails.Include(bd => bd.Booking).ToListAsync();
        }

        public async Task<BookingDetail> GetBookingDetailByIdAsync(long id)
        {
            return await _context.BookingDetails
                .Include(bd => bd.Booking)
                .FirstOrDefaultAsync(bd => bd.BookingDetailId == id);
        }

        public async Task<BookingDetail> CreateBookingDetailAsync(BookingDetail bookingDetail)
        {
            _context.BookingDetails.Add(bookingDetail);
            await _context.SaveChangesAsync();
            return bookingDetail;
        }

        public async Task UpdateBookingDetailAsync(long id, BookingDetail bookingDetail)
        {
            if (id != bookingDetail.BookingDetailId)
            {
                throw new ArgumentException("ID mismatch");
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
                    throw new KeyNotFoundException("BookingDetail not found");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteBookingDetailAsync(long id)
        {
            var bookingDetail = await _context.BookingDetails.FindAsync(id);
            if (bookingDetail == null)
            {
                throw new KeyNotFoundException("BookingDetail not found");
            }

            _context.BookingDetails.Remove(bookingDetail);
            await _context.SaveChangesAsync();
        }

        private bool BookingDetailExists(long id)
        {
            return _context.BookingDetails.Any(e => e.BookingDetailId == id);
        }
    }
}
