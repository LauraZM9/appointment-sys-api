using System;
using appointment_sys_api.Gateways.Interfaces;
using appointment_sys_api.UseCase.Interfaces;
using appointment_sys_api.Boundary.Request;
using appointment_sys_api.Boundary.Response;
using appointment_sys_api.Boundary.Response.Exceptions;
using appointment_sys_api.Factories;
using appointment_sys_api.Domain;

namespace appointment_sys_api.UseCase;

public class CreateBookingUseCase : ICreateBookingUseCase
{
    private readonly IBookingsGateway _bookingsGateway;

    public CreateBookingUseCase(IBookingsGateway bookingsGateway)
    {
        _bookingsGateway = bookingsGateway;
    }

    public BookingResponse Execute(BookingRequest request)
    {
        var booking = BuildBookingRequest(request);

        var created = _bookingsGateway.CreateBooking(booking);
        Console.WriteLine("Booking created: " + created.Id + " " + created.Name);
        return created.ToResponse();
        
    }

    private static Booking BuildBookingRequest(BookingRequest request)
    {
        return new Booking
        {
            Id = request.Id,
            Name = request.Name
        };
    }
}