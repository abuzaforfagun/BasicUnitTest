using BasicUnitTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BasicUnitTest.Repository
{
    public class BookingRepository : IBookingRepository
    {

        public IQueryable<Booking> GetActiveBooking(int?existingBookingId=null)
        {

            var unitOfWork = new UnitOfWorkBooking();
            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(b=>b.Status != "Cancelled");
            if (existingBookingId.HasValue)
                bookings = bookings.Where(b => b.Id != existingBookingId);

            return bookings;
        }
    }
}
