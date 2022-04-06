using System;
using appointment_sys_api.Gateways.Interfaces;
using appointment_sys_api.UseCase.Interfaces;
using appointment_sys_api.Boundary.Request;
using appointment_sys_api.Boundary.Response;
using appointment_sys_api.Boundary.Response.Exceptions;
using appointment_sys_api.Factories;

namespace appointment_sys_api.UseCase;

public class CreateBookingUseCase : ICreateBookingUseCase
{
    private readonly IBookingsGateway _bookingsGateway;

    public CreateBookingUseCase(IBookingsGateway bookingsGateway)
    {
        _bookingsGateway = bookingsGateway;
    }

    public BookingResponse Execute(BookingResponse request)
    {
        var booking = BuildBookingRequest(request);

        var created = _bookingsGateway.CreateBooking(booking);

        return created.ToResponse();
        
    }

    private static BookingResponse BuildBookingRequest(BookingRequest request)
    {
        return new Booking
        {
            Id = request.Id,
            Name = request.Name
        };
    }
}