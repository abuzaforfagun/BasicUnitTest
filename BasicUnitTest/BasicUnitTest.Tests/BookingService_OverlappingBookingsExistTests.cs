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
        Booking existingBooking;
        Mock<IBookingRepository> repository;


        [SetUp]
        public void Setup()
        {
            repository = new Mock<IBookingRepository>();
            existingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 10, 10),
                DepartureDate = DepartureOn(2017, 10, 13),
                Reference = "a"
            };
            bookingList = new List<Booking>
            {
                existingBooking
            };
            repository.Setup(br => br.GetActiveBooking(1))
                .Returns(bookingList.AsQueryable());
        }

        
        [Test]
        public void ArrivalBeforeArrivalDateAndDepartureBeforeArrivalDate()
        {
            var result = BookingService.OverlappingBookingsExist(
                    new Booking
                    {
                        Id = 1,
                        ArrivalDate = ArriveBeforeExistingArrivalDate(days:-10),
                        DepartureDate = ArriveBeforeExistingArrivalDate(),
                        Reference = "b",
                    }, repository.Object
                );
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ArrivalAndDepartureDateOverlappedButExistingBookingCancelled()
        {
            var result = BookingService.OverlappingBookingsExist(
                    new Booking
                    {
                        Id = 1,
                        ArrivalDate = ArriveAfterExistingArrivalDate(),
                        DepartureDate = DepartureBeforeExistingDepartureDate(),
                        Reference = "b",
                        Status = "Cancelled"

                    }, repository.Object
                );
            Assert.That(result, Is.Empty);
        }

        private DateTime ArriveAfterExistingArrivalDate(int days = 1)
        {
            return existingBooking.ArrivalDate.AddDays(days);
        }

        private DateTime ArriveBeforeExistingArrivalDate(int days = -1)
        {
            return existingBooking.ArrivalDate.AddDays(days);
        }

        private DateTime DepartureBeforeExistingDepartureDate(int days = -1)
        {
            return existingBooking.DepartureDate.AddDays(days);
        }

        private DateTime DepartureAfterExistingDepartureDate(int days = 1)
        {
            return existingBooking.DepartureDate.AddDays(days);
        }

        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartureOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
    }
}
