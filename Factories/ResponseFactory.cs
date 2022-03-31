using System.Collections.Generic;
using appointment_sys_api.Boundary.Response;
using appointment_sys_api.Domain;

namespace appointment_sys_api.Factories;

public static class ResponseFactory
{
    public static BookingResponse ToResponse( this Booking booking) {
        return new BookingResponse {
            Name = booking.Name,
            Id = bookiong.Id
        }
    }
}