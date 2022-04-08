using System;
using appointment_sys_api.Gateways.Interfaces;
using appointment_sys_api.UseCase.Interfaces;
using appointment_sys_api.Boundary.Response;
using appointment_sys_api.Boundary.Response.Exceptions;
using appointment_sys_api.Factories;

namespace appointment_sys_api.UseCase;

public class FindBookingByIdUseCase : IFindBookingByIdUseCase
{
    private readonly IBookingsGateway _bookingsGateway;

    public FindBookingByIdUseCase(IBookingsGateway bookingsGateway)
    {
        _bookingsGateway = bookingsGateway;
    }

    public BookingResponse Execute(int id)
    {
        var found = _bookingsGateway.FindBooking(id);

        if (found == null) throw new NotFoundException($"Could not find booking with id {id}");
        
        return found.ToResponse();
    }
}