using System;
using appointment_sys_api.Domain;
using appointment_sys_api.Gateways.Interfaces;
using appointment_sys_api.Infrastructure;
using appointment_sys_api.Boundary.Request;
using Microsoft.EntityFrameworkCore;


namespace appointment_sys_api.Gateways;

public class BookingsGateway : IBookingsGateway
{
    private readonly BookingDbContext _databaseContext;

    public BookingsGateway(BookingDbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public Booking FindBooking(int id)
    {
        return _databaseContext.Bookings.Find(id);
    }

    public Booking CreateBooking(Booking booking)
    {
        _databaseContext.Bookings.Add(booking);
        _databaseContext.SaveChanges();

        return booking;
    }

}