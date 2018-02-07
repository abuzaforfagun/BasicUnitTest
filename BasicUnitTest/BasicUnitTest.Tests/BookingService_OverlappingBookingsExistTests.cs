using BasicUnitTest.Repository;
using BasicUnitTest.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicUnitTest.Tests
{
    [TestFixture]
    public class BookingService_OverlappingBookingsExistTests
    {
        List<Booking> bookingList;
        Booking booking;
        Mock<IBookingRepository> repository;

        [SetUp]
        public void Setup()
        {
            repository = new Mock<IBookingRepository>();
            bookingList = new List<Booking>
            {
                new Booking{
                    Id = 2,
                    ArrivalDate = new DateTime(2017, 10, 10),
                    DepartureDate = new DateTime(2017, 10, 13),
                    Reference = "a"
                },
                new Booking{
                    Id = 3,
                    ArrivalDate = new DateTime(2017, 10, 1),
                    DepartureDate = new DateTime(2017, 10, 5),
                    Reference = "a"
                },
            };
        }

        [Test]
        public void ArrivalAndDepartureDateOverlappedButExistingBookingCancelled()
        {
            repository.Setup(br => br.GetActiveBooking(1))
                .Returns(bookingList.AsQueryable());
            var result = BookingService.OverlappingBookingsExist(
                    new Booking
                    {
                        Id = 1,
                        ArrivalDate = new DateTime(2017, 10, 1),
                        DepartureDate = new DateTime(2017, 10, 3),
                        Reference = "b",
                        Status = "Cancelled"

                    }, repository.Object
                );
            Assert.That(result, Is.Empty);
        }
    }
}
