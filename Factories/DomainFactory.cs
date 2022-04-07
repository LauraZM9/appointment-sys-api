using System;
using appointment_sys_api.Domain;
using appointment_sys_api.Infrastructure;

namespace appointment_sys_api.Factories;

public static class DomainFactory 
{
    public static Booking ToDomain(this BookingEntity entity)
    {
        return new Booking
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}