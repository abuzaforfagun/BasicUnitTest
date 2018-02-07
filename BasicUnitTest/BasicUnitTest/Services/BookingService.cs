﻿using BasicUnitTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicUnitTest.Services
{
    public static class BookingService
    {
        public static string OverlappingBookingsExist(Booking booking)
        {
            if (booking.Status == "Cancelled")
                return string.Empty;

            var bookings = new BookingRepository().GetActiveBooking(booking.Id);

            var overlappingBooking =
                bookings.FirstOrDefault(
                    b =>
                        booking.ArrivalDate >= b.ArrivalDate
                        && booking.ArrivalDate < b.DepartureDate
                        || booking.DepartureDate > b.ArrivalDate
                        && booking.DepartureDate <= b.DepartureDate);

            return overlappingBooking == null ? string.Empty : overlappingBooking.Reference;
        }
    }

    public class UnitOfWorkBooking
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }

    public class Booking
    {
        public string Status { get; set; }
        public int Id { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
        public string Reference { get; set; }
    }
}