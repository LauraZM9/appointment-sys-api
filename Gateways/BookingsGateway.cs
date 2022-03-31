using System;
using appointment_sys_api.Domain;
using appointment_sys_api.Gateways.Interfaces;
using appointment_sys_api.Infrastructure;
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
            var entity = _databaseContext.Bookings.Find(id);
            if (entity == null) return null;

            _databaseContext.Entry(entity).State = EntityState.Detached;
            return entity.ToDomain();
        }

}

