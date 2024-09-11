
using FM.Modles;
using FM.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fleetmanagement_new.Services
{
    public class BookingService:IBookingService
    {
        private readonly FMContext _context;

        public BookingService(FMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {
            return await _context.Bookings.Include(b => b.Customer).Include(b => b.CarType).ToListAsync();
        }

        public async Task<Booking> GetBookingByIdAsync(long id)
        {
            return await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.CarType)
                .FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task<IEnumerable<Booking>> GetBookingsByEmailAsync(string email)
        {
            return await _context.Bookings
                .Where(b => b.EmailId == email)
                .Include(b => b.Customer)
                .Include(b => b.CarType)
                .ToListAsync();
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<bool> UpdateBookingAsync(long id, Booking booking)
        {
            var existingBooking = await _context.Bookings.FindAsync(id);
            if (existingBooking == null) return false;

            // Update the properties of the existing booking
            existingBooking.BookingDate = booking.BookingDate;
            existingBooking.StartDate = booking.StartDate;
            existingBooking.EndDate = booking.EndDate;
            existingBooking.FirstName = booking.FirstName;
            existingBooking.LastName = booking.LastName;
            existingBooking.Address = booking.Address;
            existingBooking.State = booking.State;
            existingBooking.Pin = booking.Pin;
            existingBooking.DailyRate = booking.DailyRate;
            existingBooking.WeeklyRate = booking.WeeklyRate;
            existingBooking.MonthlyRate = booking.MonthlyRate;
            existingBooking.PHubId = booking.PHubId;
            existingBooking.RHubId = booking.RHubId;
            existingBooking.CustomerId = booking.CustomerId;
            existingBooking.CarTypeId = booking.CarTypeId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBookingAsync(long id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null) return false;

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
