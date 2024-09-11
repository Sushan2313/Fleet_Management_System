using System.Collections.Generic;
using System.Threading.Tasks;

using FM.Modles;

namespace FM.Services
{
    public interface IBookingDetailService
    {
        Task<IEnumerable<BookingDetail>> GetBookingDetailsAsync();
        Task<BookingDetail> GetBookingDetailByIdAsync(long id);
        Task<BookingDetail> CreateBookingDetailAsync(BookingDetail bookingDetail);
        Task UpdateBookingDetailAsync(long id, BookingDetail bookingDetail);
        Task DeleteBookingDetailAsync(long id);
    }
}
