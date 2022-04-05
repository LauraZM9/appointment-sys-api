using System;
using appointment_sys_api.Gateways.Interfaces;
using appointment_sys_api.UseCase.Interfaces;
using appointment_sys_api.Boundary.Response;
using appointment_sys_api.Boundary.Response.Exceptions;
using appointment_sys_api.Factories;
using appointment_sys_api.Domain;

namespace appointment_sys_api.UseCase;

public class CreateBookingUseCase : ICreateBookingUseCase
{
    private IBookingsGateway _bookingsGateway;
    // private readonly ILogger<CreateBookingUseCase> _logger;

    public BookingResponse Execute(BookingRequest request)
    {
        //  taken from https://github.com/LBHackney-IT/documents-api/blob/main/DocumentsApi/V1/UseCase/CreateClaimUseCase.cs

        // var validation = new ClaimRequestValidator().Validate(request);
        // if (!validation.IsValid)
        // {
        //     _logger.LogError("VALIDATION: {0}", validation.Errors.First().ErrorMessage);
        //     throw new BadRequestException(validation);
        // }

        var booking = BuildBookingRequest(request);

        var created = _bookingsGateway.CreateBooking(booking);

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