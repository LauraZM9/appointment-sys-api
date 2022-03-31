using System;
using appointment_sys_api.Gateways.Interfaces;
using appointment_sys_api.UseCase.Interfaces;

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

        if (found == null) throw new NotFoundException($"Could not find booking with id {id}"); //Found in Boundaries
        
        return found.ToResponse();

    }
}