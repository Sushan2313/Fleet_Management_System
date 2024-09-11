using FM.Modles;

namespace Fleetmanagement_new.Services
{
    public interface IBookingService
    {
        Task<IEnumerable<Booking>> GetBookingsAsync();
       Task<Booking> GetBookingByIdAsync(long id);
        Task<Booking> CreateBookingAsync(Booking booking);
        public  Task<IEnumerable<Booking>> GetBookingsByEmailAsync(string email);
        public Task<bool> UpdateBookingAsync(long id, Booking booking);
        public Task<bool> DeleteBookingAsync(long id);
    }
}
