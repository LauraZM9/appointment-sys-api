using System.Collections.Generic;
using appointment_sys_api.Boundary.Response;
using appointment_sys_api.Domain;

namespace appointment_sys_api.Factories;

public static class ResponseFactory
{
    public static BookingResponse ToResponse(this Booking domain) 
    {
        return new BookingResponse()
        {
            Id = domain.Id,
            Name = domain.Name,
            Council = domain.Council,
            Email = domain.Email,
            JobTitle = domain.JobTitle,
            PhoneNumber = domain.PhoneNumber
        };
    }
}