using System.Linq;
using BasicUnitTest.Services;

namespace BasicUnitTest.Repository
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBooking(int? existingBookingId = null);
    }
}