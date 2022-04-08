using System;
using appointment_sys_api.Domain;

namespace appointment_sys_api.Gateways.Interfaces;

public interface IBookingsGateway
{
    public Booking FindBooking(int id);
}
